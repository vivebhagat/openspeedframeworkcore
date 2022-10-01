using Common.DAO.Access;
using Microsoft.AspNetCore.Http;
using SpeedFramework.DAO.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SpeedFramework.APILib.Models.Authentication
{

    public class UserContext : IUserContext
    {
        IModelContext db { get; set; }

/*        public UserContext()
        {
        }*/

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext httpContext = httpContextAccessor.HttpContext;
            IAccountContext accountContext = new AccountContext(httpContext);
            this.db = new ModelContext(accountContext);

            this.preferences = new List<Tuple<string, string>>();
            if (httpContext.User.Identity.IsAuthenticated)
            {
                this.CurrentUserId = db.IntUsers.Where(m => m.Name == httpContext.User.Identity.Name).FirstOrDefault().Id;
                ClaimsIdentity cid = httpContext.User.Identity as ClaimsIdentity;
                Claim c = cid.Claims.Where(m => m.Type == "UserDefinedRole").FirstOrDefault();
                
                if (c != null)
                {
                    string values = c.Value;
                    if (!String.IsNullOrEmpty(values))
                    {
                        CurrentRoleId = Int32.Parse(values);
                    }
                }

                List<Claim> accessClaims = cid.Claims.Where(m => m.Type.StartsWith("Access.")).ToList();
                foreach (Claim accessClaim in accessClaims)
                {
                    this.preferences.Add(new Tuple<string, string>(accessClaim.Type.Replace("Access.",""), accessClaim.Value));
                }
            }
            this.db.Dispose();
        }


        public UserContext(HttpContext context)
        {
            IAccountContext accountContext = new AccountContext(context);
            this.db = new ModelContext(accountContext);

            this.preferences = new List<Tuple<string, string>>();
            if (context.User.Identity.IsAuthenticated)
            {
                this.CurrentUserId = db.IntUsers.Where(m => m.Name == context.User.Identity.Name).FirstOrDefault().Id;
                ClaimsIdentity cid = context.User.Identity as ClaimsIdentity;
                Claim c = cid.Claims.Where(m => m.Type == "UserDefinedRole").FirstOrDefault();

                if (c != null)
                {
                    string values = c.Value;
                    if (!String.IsNullOrEmpty(values))
                    {
                        CurrentRoleId = Int32.Parse(values);
                    }
                }

                List<Claim> accessClaims = cid.Claims.Where(m => m.Type.StartsWith("Access.")).ToList();
                foreach (Claim accessClaim in accessClaims)
                {
                    this.preferences.Add(new Tuple<string, string>(accessClaim.Type.Replace("Access.", ""), accessClaim.Value));
                }
            }
            this.db.Dispose();
        }

        public int CurrentUserId { get; set; }
        public int CurrentRoleId { get; set; }
        public List<Tuple<string,string>> preferences { get; set; }
    }
}