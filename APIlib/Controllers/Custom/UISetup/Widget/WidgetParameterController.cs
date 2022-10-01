using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class WidgetParameterController : GenericActivableAuthCompleteBaseController<WidgetParameter>
    {
        public IWidgetParameterRepository _service;

        public WidgetParameterController(IWidgetParameterRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }
    }
}
