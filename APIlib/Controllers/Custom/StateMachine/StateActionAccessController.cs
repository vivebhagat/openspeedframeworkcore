using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class StateActionAccessController : GenericActivableAuthCompleteBaseController<StateActionAccess>
    {
        public IStateActionAccessRepository _service;
        public StateActionAccessController(IStateActionAccessRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

    }
}
