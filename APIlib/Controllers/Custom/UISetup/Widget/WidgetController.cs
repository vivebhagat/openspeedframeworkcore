using Common.DAO.Access;
using Common.Standard;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class WidgetController : GenericActivableAuthCompleteBaseController<Widget>
    {
        public IWidgetRepository _service;

        public WidgetController(IWidgetRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }


        public ServiceResult<List<List<Widget>>> GetForDashboard(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForDashboard(Id));
        }
    }
}
