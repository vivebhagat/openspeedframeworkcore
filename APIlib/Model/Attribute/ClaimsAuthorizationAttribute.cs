using Common.DAO.Access;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using SpeedFramework.APILib.Models.Authentication;
using SpeedFramework.DAO.Commmon;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SpeedFramework.APILib.Models.Attributs
{

    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Realm { get; set; }
    }

    public class OurOwnAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        public OurOwnAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        

        protected override  Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            StringValues authorizationHeaders;
            //if (!this.Context.Request.Headers.TryGetValue("Authorization", out authorizationHeaders))
            //return AuthenticateResult.NoResult();
            IAccountContext accountContext = new AccountContext(this.Context);
            IModelContext db = new ModelContext(accountContext);
            var principal = this.Context.User as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
               // Context = new ForbidResult();
                db.Dispose();
                
                return Task.FromResult(AuthenticateResult.Fail("Header was not found"));

            }
            db.Dispose();

            {
                bool _IsInrole = false;
               // var _roles = Context.Request.Headers.Where(m => m.Key.ToLower() == "userrole");
                var roles = principal.Claims.Where(m => m.Type.ToLower() == "userdefinedrole").Select(m => m.Value).FirstOrDefault();

                if (roles == null)
                {
                    _IsInrole = false;
                }
                else
                {
                    //if (roles.Select(m => m) == null)
                    if (roles == null)
                    {
                        _IsInrole = false;
                    }
                    else
                    {
                        //if (roles.Select(m => m).FirstOrDefault() == null)
                        if (roles == null)
                        {
                            _IsInrole = false;
                        }
                        else
                        {
                            //                            if (roles.Select(m => m).FirstOrDefault().FirstOrDefault() == null)
                            if (roles == null)
                            {
                                _IsInrole = false;
                            }
                            else
                            {
                                _IsInrole = true;
                            }
                        }
                    }
                }
                string definedrole = null;
                if (_IsInrole)
                {
                    //                    definedrole = actionContext.Request.Headers.Where(m => m.Key.ToLower() == "userrole").Select(m => m.Value).FirstOrDefault().FirstOrDefault();
                    definedrole = roles;
                }

                string orgid = "1"; //actionContext.Request.Headers.Where(m => m.Key == "OrgId").Select(m => m.Value).FirstOrDefault().FirstOrDefault();
                //               IEnumerable<string> orgid = actionContext.Request.Headers.GetValues("OrgId");



                if (!String.IsNullOrEmpty(definedrole))
                {
                    if (orgid != null)
                    {
                        if (!String.IsNullOrEmpty(orgid))
                        {

                            try
                            {

                                int oid = Int32.Parse(orgid);
                                int userroleid = Int32.Parse(definedrole);
                                int count = db.UserDefinedRoles.Where(m => m.Id == userroleid).Count();
                                if (count != 1)
                                {
                                    Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                 //                   Context.Result = new ForbidResult();
                                    db.Dispose();
                                    return Task.FromResult(AuthenticateResult.Fail("Header was not found"));
                                }
                            }
                            catch (Exception e)
                            {
                                Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
//                                Context.Response = new ForbidResult();
                                db.Dispose();
                                return Task.FromResult(AuthenticateResult.Fail("Header was not found"));
                            }
                        }
                    }
                }
                else
                {
                    Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    db.Dispose();
                    return Task.FromResult(AuthenticateResult.Fail("Header was not found"));

                }
            }
            db.Dispose();
            // ... return AuthenticateResult.Fail(exceptionMessage);
            // ... return AuthenticateResult.Success(ticket)
            return Task.FromResult(AuthenticateResult.Fail("Header was not found"));
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 401;
            var message = "tell me your token";
            Response.Body.Write(Encoding.UTF8.GetBytes(message));
            return Task.CompletedTask;
        }

        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 403;
            var message = "you have no rights";
            Response.Body.Write(Encoding.UTF8.GetBytes(message));
            return Task.CompletedTask;
        }

    }

    public interface IClaimsAuthorization
    {

        void OnAuthorization(AuthorizationFilterContext context);
    }

    public class ClaimsAuthorization : AuthorizeAttribute, IAuthorizationFilter, IClaimsAuthorization
    {
        public ClaimsAuthorization()
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
                context.Result = new ForbidResult();
                db.Dispose();
                return;
            }
//            db.Dispose();

                // var _roles = context.HttpContext.Request.Headers.Where(m => m.Key.ToLower() == "userrole");
                var roles = principal.Claims.Where(m => m.Type.ToLower() == "userdefinedrole")?.Select(m=>m.Value)?.FirstOrDefault();

                // string orgid = "1"; //actionContext.Request.Headers.Where(m => m.Key == "OrgId").Select(m => m.Value).FirstOrDefault().FirstOrDefault();
                // IEnumerable<string> orgid = actionContext.Request.Headers.GetValues("OrgId");

            if (!String.IsNullOrEmpty(roles))
            {
                try
                {
                    int userroleid;
                    bool isValidRole  = Int32.TryParse(roles, out userroleid);
                    if (isValidRole)
                    {
                        int count = db.UserDefinedRoles.Where(m => m.Id == userroleid).Count();
                        if (count != 1)
                        {
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Result = new ForbidResult();
                            db.Dispose();
                            return;
                        }
                    }
                    else 
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new ForbidResult();
                        db.Dispose();
                        return;
                    }
                }
                catch (Exception e)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new ForbidResult();
                    db.Dispose();
                    return;
                }
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new ForbidResult();
                db.Dispose();
                return;                    
            }
            
            db.Dispose();
            //User is Authorized, complete execution
        }
    }
}