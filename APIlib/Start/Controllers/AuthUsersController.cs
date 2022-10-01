using WebApi.Services;
using WebApi.Models;
using SpeedFramework.APILib.Models.Attributs;
using SpeedFramework.APILib.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common.DAO.Access;
using SpeedFramework.DAO.Commmon;
using Microsoft.AspNetCore.Http;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [TypeFilter(typeof(WebApiClaimsUserFilter))]
    [TypeFilter(typeof(CustomErrorFilter))]
    public class AuthUsersController : AuthStageBaseController
    {
        private IUserService _userService;

        public AuthUsersController(IUserService userService, IUserContext userContext)
        {
            _userService = userService;
            this._userContext = userContext;
        }

        [HttpPost("oauth2/token")]
        public async Task<IActionResult> RefreshToken([FromBody] AuthenticateRequest model, [FromServices]IAccountContext accountContext, [FromServices]IModelContext modelContext, [FromServices] IStageService stageService)
        {
            var response = await _userService.RefreshToken(new Entities.User{ 
                CurrentToken = model.CurrentToken,
                Username = model.Username,
                UserDefinedRole = model.UserDefinedRole                 
                
            }, ipAddress(), this.HttpContext, accountContext, modelContext, stageService);

            if (response == null)
                return BadRequest(new { message = "Refresh token is invalid." });

            setTokenCookie(response.refresh_token);

            return Ok(response);
        }

        [HttpPost("api/intuserstage/getrolemap")]
        public async Task<IActionResult> GetRoleMap([FromServices]IAccountContext accountContext, [FromServices]IModelContext modelContext, [FromServices] IStageService stageService)
        {
            /*
            var response = await _userService.RefreshToken(new Entities.User
            {
                CurrentToken = model.CurrentToken,
                Username = model.Username,
                UserDefinedRole = model.UserDefinedRole

            }, ipAddress(), this.HttpContext, accountContext, modelContext, stageService);

            if (response == null)
                return BadRequest(new { message = "Refresh token is invalid." });

            setTokenCookie(response.RefreshToken);
            */
            return Ok();
        }

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

    }
}
