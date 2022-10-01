using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class WidgetTemplateController : GenericActivableAuthCompleteBaseController<WidgetTemplate>
    {
        public IWidgetTemplateRepository _service;

        public WidgetTemplateController(IWidgetTemplateRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }
    }
}
