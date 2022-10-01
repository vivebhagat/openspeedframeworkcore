using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class ApplicationEntityPropertyController : GenericAuthCompleteBaseController<ApplicationEntityProperty>
    {
        public IApplicationEntityPropertyRepository _service;

        public ApplicationEntityPropertyController(IApplicationEntityPropertyRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public  ServiceResult<IEnumerable<ApplicationEntityProperty>> GetForApplicationEntity(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForApplicationEntity(Id));
        }

    }
}
