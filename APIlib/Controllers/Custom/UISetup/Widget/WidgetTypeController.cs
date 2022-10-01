using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class WidgetTypeController : GenericActivableAuthCompleteBaseController<WidgetType>
    {
        public IWidgetTypeRepository _service;

        public WidgetTypeController(IWidgetTypeRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }
    }
}
