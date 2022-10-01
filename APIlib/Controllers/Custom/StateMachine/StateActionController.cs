using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{
    public class StateActionController : GenericActivableAuthCompleteBaseController<StateAction>
    {
        public IStateActionRepository _service;

        public StateActionController(IStateActionRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }


        [HttpGet]
        public ServiceResult<IEnumerable<StateAction>> GetForEntity(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForEntity(Id));
        }

    }
}
