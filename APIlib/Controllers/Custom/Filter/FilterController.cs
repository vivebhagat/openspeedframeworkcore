using Common.DAO.Access;
using Common.Filter;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class FilterController : GenericActivableAuthCompleteBaseController<Filter>
    {
        public IFilterRepository _service;

        public FilterController(IFilterRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<Filter>> GetForEntity(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForEntity(Id));
        }


        [HttpGet]
        public  ServiceResult<FilterResult<dynamic>> Filter(int Id, int s, int n)
        {
            return ResultProcessor.Process(() => _service.Filter(Id,s,n));
        }


        [HttpPost]
        public ServiceResult<FilterResult<dynamic>> _postFilter(PostFilter postFilter)
        {
            return ResultProcessor.Process(() => _service._postFilter(postFilter.Id, postFilter.filterFields, postFilter.s, postFilter.n));
        }
    }
}
