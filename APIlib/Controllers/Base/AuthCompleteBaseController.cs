using Common.DAO.Access;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.APILib.Models.Attributs;

namespace SpeedFramework.APILib.Controllers
{
    //  [EnableCors(origins: "*", headers: "*", methods: "*")]    
    [TypeFilter(typeof(WebApiClaimsUserFilter))]
    [ClaimsAuthorization]
    [TypeFilter(typeof(CustomErrorFilter))]
    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public class AuthCompleteBaseController : ControllerBase
    {
        public IUserContext _userContext;
        public IAccountContext _accountContext;
    }
}
