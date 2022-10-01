using APIlib;
using Common.DAO.Access;
using Common.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedFramework.APILib.Models.Authentication;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Access;
using System;
using System.Collections.Generic;
using WebApi.Helpers;

namespace SpeedFramework.APILib.Controllers
{

    

    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public class SuperController : ControllerBase
    {

        IHttpContextAccessor httpContextAccessor;
        AppSettings appSettings;
        public SuperController(IHttpContextAccessor httpContextAccessor, AppSettings appSettings)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.appSettings = appSettings;
        }


        [HttpGet]
        public void RunSetup(string domain)
        {
            DbContextOptions<AccountDbContext> options = new DbContextOptionsBuilder<AccountDbContext>().UseSqlServer(appSettings.AccountConnection).Options;
            AccountDbContext accountDbContext = new AccountDbContext(options);
            this.ControllerContext.HttpContext.Request.Headers.Add("domain", domain);
            IAccountContext accountContext = new AccountContext(this.httpContextAccessor);
            InitialSetup(accountContext);
            BuildClientsList(accountContext);

        }

        
        private static async void InitialSetup(IAccountContext accountContext)
        {

            string initial_username = accountContext.default_username;
            string initial_password = accountContext.default_password;
            if (!String.IsNullOrEmpty(initial_username))
            {
                if (!String.IsNullOrEmpty(initial_username) & !String.IsNullOrEmpty(initial_password))
                {
                    AuthRepository authRepository = new AuthRepository(accountContext);
                    IdentityUser identityUser = authRepository.FindUser(initial_username, initial_password);
                    if (identityUser != null)
                    {
                        return;
                    }
                    Models.Authentication.UserModel userModel = new Models.Authentication.UserModel
                    {
                        UserName = initial_username,
                        Password = initial_password,
                        ConfirmPassword = initial_password,
                    };

                    string userId = await authRepository.RegisterUserId(userModel);
                    authRepository.Dispose();
                    Organization organisation = new Organization
                    {
                        CreatedDate = DateTime.Now,
                        Currency = CurrencyType.INR,
                        Name = "Basic",
                        IsParent = true
                    };
                    IModelContext db = new ModelContext(accountContext);
                    db.Organizations.Add(organisation);
                    db.SaveChanges();
                    IntUser intUser = new IntUser
                    {
                        Org = organisation,
                        OrgId = organisation.Id,
                        DOB = new DateTime(1987, 7, 5),
                        //CreatedDate = DateTime.Now,
                        Email = initial_username,
                        UserId = userId,
                        Name = initial_username
                    };
                    db.IntUsers.Add(intUser);
                    db.SaveChanges();


                    string initial_role = accountContext.default_role;
                    UserDefinedRole userDefinedRole = new UserDefinedRole
                    {
                        Org = organisation,
                        OrgId = organisation.Id,
                        Name = initial_role
                    };
                    db.UserDefinedRoles.Add(userDefinedRole);
                    db.SaveChanges();
                    UserDefinedRoleToUserMap userDefinedRoleMap = new UserDefinedRoleToUserMap
                    {
                        IntUser = intUser,
                        IntUserId = intUser.Id,
                        Role = userDefinedRole,
                        RoleId = userDefinedRole.Id
                    };
                    db.UserDefinedRoleToUserMaps.Add(userDefinedRoleMap);
                    db.SaveChanges();

                    List<PageLink> pagelinks = new List<PageLink>();
                    pagelinks.Add(new PageLink { linkName = "Roles", pageName = "Custom", url = "/Account/Roles" });
                    pagelinks.Add(new PageLink { linkName = "Links", pageName = "Custom", url = "/Account/Page" });

                    foreach (PageLink link in pagelinks)
                    {
                        db.PageLinks.Add(link);
                        db.SaveChanges();
                        PageAccess pageAccess = new PageAccess
                        {
                            Role = userDefinedRole,
                            RoleId = userDefinedRole.Id,
                            Link = link,
                            LinkId = link.Id
                        };
                        db.PageAccesses.Add(pageAccess);
                        db.SaveChanges();
                    }
                    db.Dispose();
                }
            }
        }

        private static void BuildClientsList(IAccountContext accountContext)
        {
            try
            {

                AuthContext context = new AuthContext(accountContext);
                List<Client> ClientsList = new List<Client>
            {
                new Client
                { Id = "ngAuthApp",
                    Secret= Helper.GetHash("abc@123"),
                    Name="AngularJS front-end Application",
                    ApplicationType =  ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "http://ngauthenticationweb.azurewebsites.net"
                },
                new Client
                { Id = "consoleApp",
                    Secret=Helper.GetHash("123@abc"),
                    Name="Console Application",
                    ApplicationType =ApplicationTypes.NativeConfidential,
                    Active = true,
                    RefreshTokenLifeTime = 14400,
                    AllowedOrigin = "*"
                }
                };
                context.Clients.AddRange(ClientsList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
            }

        }

    }
}
