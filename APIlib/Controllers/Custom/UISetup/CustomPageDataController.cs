using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public class CustomPageDataController : ControllerBase
    {
        public ICustomPageLinkRepository _service;

        public CustomPageDataController(ICustomPageLinkRepository service, IUserContext userContext)
        {
            _service = service;
        }


        [HttpGet]
        public ServiceResult<IEnumerable<CustomPageLink>> GetForPage(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForPage(Id));
        }

    }
}
