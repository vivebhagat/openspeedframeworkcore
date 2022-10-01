using Common.DAO.Access;
using Microsoft.AspNetCore.Mvc.Filters;
using SpeedFramework.APILib.Models.Authentication;
using SpeedFramework.DAO.Commmon;
using System.Net;
using System.Security.Claims;


namespace SpeedFramework.APILib.Models.Attributs
{
    public interface IClaimsAuthorizationStage
    {
        void OnAuthorization(AuthorizationFilterContext context);
    }
    public class ClaimsAuthorizationStage : IAuthorizationFilter, IClaimsAuthorizationStage
    {
        public ClaimsAuthorizationStage()
        {
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {            
            IAccountContext accountContext = new AccountContext(context.HttpContext);
            IModelContext db = new ModelContext(accountContext);
            var principal = context.HttpContext.User as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                db.Dispose();
            }

            db.Dispose();
            // User is Authorized, complete execution
            // return Task.FromResult<object>(null);
        }
    }
}