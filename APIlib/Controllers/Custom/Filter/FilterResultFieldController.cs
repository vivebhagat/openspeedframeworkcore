using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class FilterResultFieldController : GenericActivableAuthCompleteBaseController<FilterResultField>
    {
        public IFilterResultFieldRepository _service;

        public FilterResultFieldController(IFilterResultFieldRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }


        [HttpGet]
        public ServiceResult<IEnumerable<FilterResultField>> GetForFilter(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForFilter(Id));
        }
    }
}
