using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Scripting;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{

    public class ScriptController : GenericActivableAuthCompleteBaseController<Script>
    {
        IScriptRepository _service;

        public ScriptController(IScriptRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            this._service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpPut]
        public ServiceResult<dynamic> RunScript(int Id, dynamic payload)
        {
            return ResultProcessor.Process(() => _service.RunScript(payload, Id));
        }



    }
}

