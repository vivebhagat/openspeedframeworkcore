using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class CommunicationController : GenericAuthCompleteBaseController<Communication>
    {
        public ICommunicationRepository _service;
        public CommunicationController(ICommunicationRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }
    }
}
