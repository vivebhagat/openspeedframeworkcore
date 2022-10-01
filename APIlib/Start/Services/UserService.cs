using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;
using WebApi.Entities;
using WebApi.Helpers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using SpeedFramework.APILib.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Common.DAO.Access;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpeedFramework.DAO.Commmon;
using System.Net.Http;
using System.Globalization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;

namespace WebApi.Services
{

    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress, HttpContext context);
        Task<AuthenticateResponse> RefreshToken(User uiUser, string ipAddress, HttpContext context, IAccountContext accountContext, IModelContext moddelContext, IStageService stageService);
        Task<bool> Register(AuthenticateRequest model, string ipAddress, HttpContext context, IStageService stageService);
        IEnumerable<CommonApplicationUser> GetAll();
        CommonApplicationUser GetById(int id);
    }


    public class UserService : IUserService
    {
        private AuthContext _context;
        private readonly AppSettings _appSettings;

        private UserManager<CommonApplicationUser> _userManager;

        public UserService(ILogger<UserManager<CommonApplicationUser>> logger)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            string connection = configuration.GetValue(typeof(string), "AppSettings:ConnectionStrings:UserConnection").ToString();

            _appSettings = new AppSettings();
            _appSettings.Secret = configuration.GetValue<string>("AppSettings:Secret").ToString();

            DbContextOptions<AuthContext> options = new DbContextOptionsBuilder<AuthContext>().UseSqlServer(connection).Options;
            _context = new AuthContext(options);

            _userManager = new UserManager<CommonApplicationUser>(new UserStore<CommonApplicationUser>(_context), null, new PasswordHasher<CommonApplicationUser>(), null, null, null, null, null, logger);

        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress, HttpContext context)
        {
            var user =
                _context.Users.SingleOrDefault(m => m.UserName == model.Username);

            // return null if user not found
            if (user == null)
                return null;

            var userCheckResult = await _userManager.FindByNameAsync(model.Username);
            if (userCheckResult != null)
            {
                bool passwordCheckResult = false;
                try
                {
                     passwordCheckResult = await _userManager.CheckPasswordAsync(userCheckResult, model.Password);
                }
                catch(Exception e)
                {
                    return null;
                }

                if (!passwordCheckResult)
                     return null;
            }
            else 
            {
                return null;
            }

            User _user = new User
            {
                Username = user.UserName,
                UserDefinedRole = model.UserDefinedRole,
                RefreshTokens = new List<Entities.RefreshToken>(),
                DataRoute = userCheckResult.dataroute,
                domainkey = userCheckResult.domainkey.ToString()
            };

            // authentication successful so generate jwt and refresh tokens
            var tokenid = Guid.NewGuid();
            var jwtToken = await generateJwtToken(_user, tokenid);
            var refreshToken = generateRefreshToken(ipAddress, tokenid);

            try
            {
                // save refresh token
                _context.RefreshTokens.Add(new SpeedFramework.APILib.Models.Authentication.RefreshToken
                {
                    Id = tokenid.ToString(),
                    Subject = _user.Username,
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.AddMinutes(10),
                    ProtectedTicket = refreshToken.Token,
                    ClientId = "ngAuthApp",
                });
                _context.Update(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var ee = e;
            }
            return new AuthenticateResponse(_user, jwtToken, refreshToken.Token, DateTime.Now, DateTime.Now.AddMinutes(10));
        }


        public async Task<bool> Register(AuthenticateRequest model, string ipAddress, HttpContext context, IStageService stageService)
        {
            var user =
                _context.Users.SingleOrDefault(m => m.UserName == model.Username);

            // return null if user not found
            if (user != null) 
                return false;

            CommonApplicationUser _user = new CommonApplicationUser
            {
                UserName = model.Username,
                Password = model.Password,
                Email = "test@test.com",
                dataroute = String.IsNullOrEmpty(model.DataRoute) ? "intuser" : model.DataRoute,
                ConfirmPassword = model.Password
             };
            
            try
            {
                var result = _userManager.CreateAsync(_user).Result;
                if (!result.Succeeded)
                    return false;

                var savedUser = _userManager.FindByNameAsync(_user.UserName).Result;
                var addPasswordResult = _userManager.AddPasswordAsync(savedUser, _user.Password).Result;

                if (!addPasswordResult.Succeeded)
                    return false;
                
                CultureInfo provider = CultureInfo.InvariantCulture;

                stageService.AddUser(_user.dataroute,
                    new Dictionary<string, string>{
                        { "FirstName" , _user.UserName },
                        { "Email", _user.Email },
                        { "DOB", "01/12/2020"},
                        { "Name", _user.UserName  }
                    });
                return true;
            }
            catch(Exception e)
            {                
                return false;
            }
        }

        
        public async Task<AuthenticateResponse> RefreshToken(User uiUser,  string ipAddress, HttpContext context, IAccountContext accountContext, IModelContext modelContext, IStageService stageService)
        {
            var tokenId = context.User.Claims.Where(m => m.Type == "tokenid").FirstOrDefault();
            if(tokenId == null)
                return null;

            var dataroute = context.User.Claims.Where(m => m.Type == "dataroute").FirstOrDefault();
            if (dataroute == null)
                return null;

           var refreshToken = _context.RefreshTokens.SingleOrDefault(u => u.Id == tokenId.Value);
            if (refreshToken.ProtectedTicket != uiUser.CurrentToken)
                return null;

           var username =  context.User.Identity.Name;
           var user = _context.Users.SingleOrDefault(u => u.UserName == username);
            
            // return null if no user found with token
            if (user == null) 
                return null;


            if (refreshToken.ProtectedTicket != uiUser.CurrentToken || refreshToken.Subject != username)
                return null;


            if (refreshToken.ExpiresUtc < DateTime.Now) 
                return null;

            var roleMap = stageService.GetRolesForUser(dataroute.Value, username);

            if (!roleMap.ContainsKey(uiUser.UserDefinedRole))
                return null;
            // generate new jwt
            var _user = new User { 
                Username = username,
                UserDefinedRole = uiUser.UserDefinedRole,
                domainkey = user.domainkey.ToString()
            };

            var jwtToken = await generateJwtToken(_user, Guid.Parse(tokenId.Value));

            var newRefreshToken = generateRefreshToken(ipAddress, Guid.Parse(tokenId.Value));

            try
            {
                // save refresh token
                refreshToken.ProtectedTicket = newRefreshToken.Token;
                refreshToken.IssuedUtc = DateTime.Now;
                refreshToken.ExpiresUtc = DateTime.Now.AddMinutes(20);
                _context.RefreshTokens.Update(refreshToken);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }

            return new AuthenticateResponse(_user, jwtToken, newRefreshToken.Token, DateTime.Now, DateTime.Now.AddMinutes(20));
        }
        

        
        /*
        public bool RevokeToken(string token, string ipAddress)
        {
            var user = _context.RefreshTokens.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            
            // return false if no user found with token
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return false if token is not active
            if (!refreshToken.IsActive) return false;

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            _context.Update(user);
            _context.SaveChanges();

            return true;
        } 
        */


        public IEnumerable<CommonApplicationUser> GetAll()
        {
            return _context.Users;
        }

        public CommonApplicationUser GetById(int id)
        {
            return _context.Users.Find(id);
        }

        // helper methods

        private async Task<string> generateJwtToken(User user, Guid tokenid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            List<Claim> claims = new List<Claim>();
            
            if(user.UserDefinedRole > 0 )
                claims.Add(new Claim("UserDefinedRole", "" + user.UserDefinedRole));

            if (tokenid != Guid.Empty)
                claims.Add(new Claim("tokenid", tokenid.ToString()));

            if (!string.IsNullOrEmpty(user.DataRoute))
                claims.Add(new Claim("dataroute", user.DataRoute.ToString()));

            claims.Add(new Claim(ClaimTypes.Name, user.Username.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {   
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            ////////////////////////
            

          //  var identity = new ClaimsIdentity(context.Options.AuthenticationType);

          //  identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
          //  identity.AddClaim(new Claim("sub", context.UserName));

 
           /////////////////////////


            return tokenHandler.WriteToken(token);
        }

        private Entities.RefreshToken generateRefreshToken(string ipAddress, Guid id)
        {
            using(var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new Entities.RefreshToken
                {
                    Id = id.ToString(),
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }
    }
}