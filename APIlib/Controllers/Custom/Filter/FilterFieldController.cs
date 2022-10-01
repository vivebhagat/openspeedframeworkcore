using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class FilterFieldController : GenericActivableAuthCompleteBaseController<FilterField>
    {
        public IFilterFieldRepository _service;

        public FilterFieldController(IFilterFieldRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<object>> GetFieldOperatorList()
        {
            return ResultProcessor.Process(() => _service.GetFieldOperatorList());
        }



        [HttpGet]
        public ServiceResult<IEnumerable<FilterField>> GetForFilter(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForFilter(Id));
        }
    }
}
