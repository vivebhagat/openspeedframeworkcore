using Common.DAO.Access;
using Common.Standard;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class DashboardController : GenericActivableAuthCompleteBaseController<Dashboard>
    {

        public IDashboardRepository _service;

        public DashboardController(IDashboardRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }


        public ServiceResult<Dashboard> GetQuickDashboard()
        {
            return ResultProcessor.Process(() => _service.GetQuickDashboard());
        }

    }
}
