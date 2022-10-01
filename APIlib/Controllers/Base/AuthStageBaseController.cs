using Common.DAO.Access;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.APILib.Models.Attributs;

namespace SpeedFramework.APILib.Controllers
{
    //  [EnableCors(origins: "*", headers: "*", methods: "*")]

    [TypeFilter(typeof(WebApiClaimsUserFilter))]
//    [ClaimsAuthorization]
 //   [Authorize]
    [TypeFilter(typeof(CustomErrorFilter))]
    [ApiController]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public class AuthStageBaseController : ControllerBase
    {
        public IUserContext _userContext;
        public IAccountContext _accountContext;
    }
}
