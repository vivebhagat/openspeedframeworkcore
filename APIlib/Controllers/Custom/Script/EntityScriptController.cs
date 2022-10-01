using Common.DAO.Access;
using Common.Enum;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Scripting;
using SpeedFramework.DAO.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class EntityScriptController : GenericActivableAuthCompleteBaseController<EntityScript>
    {
        public IEntityScriptRepository _service;

        public EntityScriptController(IEntityScriptRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<Tuple<string, string>>> GetSubmitEventTypes()
        {
            List<Tuple<string, string>> triggerTypes = new List<Tuple<string, string>>();
            triggerTypes.Add(new Tuple<string, string>("" + (int)SubmitEventType.AFTER_ADD, Enum.GetName(typeof(SubmitEventType), SubmitEventType.AFTER_ADD)));
            triggerTypes.Add(new Tuple<string, string>("" + (int)SubmitEventType.BEFORE_ADD, Enum.GetName(typeof(SubmitEventType), SubmitEventType.BEFORE_ADD)));
            triggerTypes.Add(new Tuple<string, string>("" + (int)SubmitEventType.AFTER_EDIT, Enum.GetName(typeof(SubmitEventType), SubmitEventType.AFTER_EDIT)));
            triggerTypes.Add(new Tuple<string, string>("" + (int)SubmitEventType.BEFORE_EDIT, Enum.GetName(typeof(SubmitEventType), SubmitEventType.BEFORE_EDIT)));

            return new ServiceResult<IEnumerable<Tuple<string, string>>> { Result = triggerTypes };
        }
    }

}
