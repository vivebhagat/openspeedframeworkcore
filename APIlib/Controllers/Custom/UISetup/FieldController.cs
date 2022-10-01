using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class FieldController : GenericActivableAuthCompleteBaseController<Field>
    {
        public IFieldRepository _service;

        public FieldController(IFieldRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }


        [HttpGet]
        public ServiceResult<IEnumerable<Field>> GetForEntity(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForEntity(Id));
        }


        [HttpGet]
        public ServiceResult<IEnumerable<Option>> GetOptions(int Id)
        {
            return ResultProcessor.Process(() => _service.GetOptions(Id));
        }

    }
}
