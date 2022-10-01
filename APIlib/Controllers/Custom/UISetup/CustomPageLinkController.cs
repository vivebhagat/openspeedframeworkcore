using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class CustomPageLinkController : GenericActivableAuthCompleteBaseController<CustomPageLink>
    {
        public ICustomPageLinkRepository _service;

        public CustomPageLinkController(ICustomPageLinkRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }


        [HttpGet]
        public ServiceResult<IEnumerable<CustomPageLink>> GetForPage(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForPage(Id));
        }

    }
}
