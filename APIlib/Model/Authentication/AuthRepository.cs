using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.DAO.Access;
using Microsoft.AspNetCore.Identity;

namespace SpeedFramework.APILib.Models.Authentication
{

    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            // IAccountContext accountContext = new AccountContext();
            //     _ctx = new AuthContext(accountContext);
            // _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
            // _userManager = new UserManager<IdentityUser>();
        }

        public AuthRepository(IAccountContext accountContext)
        {
            _ctx = new AuthContext(accountContext);
            //   _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public bool IsInRole(IdentityUser user, string RoleName)
        {
            return _userManager.IsInRoleAsync(user, RoleName).Result;
        }


        public async Task<string> RegisterUserId(UserModel userModel)
        {
            try
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email
                };

                var result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    return _userManager.FindByNameAsync(user.UserName).Result.Id;
                }
                else
                {
                    throw new Exception("Error while creating user."); ;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error while creating user.");
            }

        }

        public async Task<bool> UpdateLoginData(UserModel userModel)
        {
            try
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email
                };

                IdentityUser iUser = _userManager.FindByNameAsync(userModel.UserName).Result;
                var result = await _userManager.RemovePasswordAsync(iUser);

                if (result.Succeeded)
                {
                    var _reset_password_result = await _userManager.AddPasswordAsync(iUser, userModel.Password);
                    if (_reset_password_result.Succeeded)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Error while updating login data."); ;
                    }
                }
                throw new Exception("Error while updating login data.");
            }
            catch (Exception e)
            {
                throw new Exception("Error while updating login data.");
            }

        }


        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);


            return result;
        }

        public async Task<IdentityUser> FindUserAsync(string userName, string password)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public IdentityUser FindUser(string userName, string password)
        {
            IdentityUser user = _userManager.FindByNameAsync(userName).Result;

            return user;
        }

        public Client FindClient(string clientId)
        {
            var client = _ctx.Clients.Find(clientId);

            return client;
        }


        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            var existingToken = _ctx.RefreshTokens.Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            _ctx.RefreshTokens.Add(token);

            return await _ctx.SaveChangesAsync() > 0;
        }


        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                _ctx.RefreshTokens.Remove(refreshToken);
                return await _ctx.SaveChangesAsync() > 0;
            }

            return false;
        }


        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            _ctx.RefreshTokens.Remove(refreshToken);
            return await _ctx.SaveChangesAsync() > 0;
        }


        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }


        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _ctx.RefreshTokens.ToList();
        }



        public async Task<IdentityResult> CreateAsync(IdentityUser user)
        {
            var result = await _userManager.CreateAsync(user);

            return result;
        }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}