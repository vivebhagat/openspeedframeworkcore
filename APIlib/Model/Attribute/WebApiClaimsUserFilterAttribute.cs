using Common.DAO.Access;
using Microsoft.AspNetCore.Mvc.Filters;
using SpeedFramework.APILib.Controllers;
using SpeedFramework.APILib.Models.Authentication;


namespace SpeedFramework.APILib.Models.Attributs
{
    public class WebApiClaimsUserFilter : IActionFilter
    {

        public WebApiClaimsUserFilter()
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext actionContext)
        {

          //  var context = new HttpContextWrapper(HttpContext.Current);
          /*
            var userContext = new UserContext(actionContext.HttpContext);
            IUserContext _userContext = null;

            var controller = actionContext.Controller;
            
            if (controller is AuthCompleteBaseController)
            {
                var _controller = (AuthCompleteBaseController)actionContext.Controller;
                _controller._userContext = _userContext;
                _userContext.CurrentRoleId = userContext.CurrentRoleId;
                _userContext.CurrentUserId = userContext.CurrentUserId;
                _userContext.preferences = userContext.preferences;
            }
            if (controller is AuthStageBaseController)
            {
                var _controller = (AuthStageBaseController)actionContext.Controller;
                _userContext = _controller._userContext;
                _userContext.CurrentRoleId = userContext.CurrentRoleId;
                _userContext.CurrentUserId = userContext.CurrentUserId;
                _userContext.preferences = userContext.preferences;
            }
            if(controller is UnAuthBaseController)
            {
                var _controller = (UnAuthBaseController)actionContext.Controller;
                _userContext = _controller._userContext;
                _userContext.CurrentRoleId = userContext.CurrentRoleId;
                _userContext.CurrentUserId = userContext.CurrentUserId;
                _userContext.preferences = userContext.preferences;

            }
            */

          

       //     base.OnActionExecuting(actionContext);
        }
    }
}