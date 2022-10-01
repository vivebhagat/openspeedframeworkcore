using Common.DAO.Access;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public class GlobalController : ControllerBase
    {
        IGlobalRepository _service;
        IUserContext userContext;
        IAccountContext _accountContext;
        public GlobalController(IGlobalRepository service, IUserContext userContext, IAccountContext accountContext)
        {
            this._service = service;
            this.userContext = userContext;
            this._accountContext = accountContext;
        }

        [HttpGet]
        public IEnumerable<dynamic> Search(string q)
        {
            return _service.Search(q);
        }
    }
}
