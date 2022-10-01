using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class FilterListController : GenericActivableAuthCompleteBaseController<FilterList>
    {
        public IFilterListRepository _service;

        public FilterListController(IFilterListRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        
        [HttpGet]
        public ServiceResult<IEnumerable<object>> LoadForFilterField(int Id, int s, int n)
        {
            return ResultProcessor.Process(() => _service.LoadForFilterField(Id, s, n));
        }

    }
}
