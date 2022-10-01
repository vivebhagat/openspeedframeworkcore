using Common.DAO.Access;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{

    public class IntUserController : GenericUserAuthCompleteBaseController<IntUser>
    {
        public IIntUserRepository _service;

        public IntUserController (IIntUserRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

     
    }
}
