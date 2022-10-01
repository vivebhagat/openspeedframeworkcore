using APIlib;
using Common.DAO.Access;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedFramework.APILib.Models.Authentication;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApi.Helpers;

namespace SpeedFramework.APILib.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public class ExtUIController : ControllerBase
    {
        IHttpContextAccessor httpContextAccessor;
        AppSettings appSettings;
        public ExtUIController(IHttpContextAccessor httpContextAccessor, AppSettings appSettings)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.appSettings = appSettings;
        }
        [HttpGet]
        public HttpResponseMessage Render(string name)
        {
            var pathandquery = Request.Path + Request.QueryString;
            var _domain = pathandquery.Split('/')[2];
            this.HttpContext.Request.Headers.Add("domain", _domain);

            ModelContext db = new ModelContext(new AccountContext(this.httpContextAccessor));
            CustomPage  cp = db.CustomPages.Where(m => m.Name == name).FirstOrDefault();
            string cp_name = "NILL";
            var response = new HttpResponseMessage();
            if (cp.IsPublic)
            {
//                cp_name = cp.Name;
                //string content_string = File.ReadAllText(@"C:\Users\Vivek.bhagat\source\Workspaces\SpeedFramework\WebApplication1\Scripts\app\index.html");
                string content_string = cp.Content;
                content_string = content_string.Replace("[[domain_token]]", _domain);
                response.Content = new StringContent(content_string);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                return response;
            }
            response.StatusCode = HttpStatusCode.InternalServerError;
            return response;
        }
    }

    public class AuthExtUIController : GenericActivableAuthCompleteBaseController<CustomPage>
    {
        public ICustomPageRepository _service;

        public AuthExtUIController(ICustomPageRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public HttpResponseMessage Render()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<div>Hello World</div><script> alert('TRt')</script>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            return response;
        }
    }

    public class CustomPageController : GenericActivableAuthCompleteBaseController<CustomPage>
    {
        public ICustomPageRepository _service;

        public CustomPageController(ICustomPageRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }
        
        [HttpGet]
        public HttpResponseMessage Render()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<div>Hello World</div><script> alert('TRt')</script>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            return response;
        }

    }
}
