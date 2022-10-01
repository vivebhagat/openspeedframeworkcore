using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class CommunicationTypeController : GenericActivableAuthCompleteBaseController<CommunicationType>
    {
        public ICommunicationTypeRepository _service;

        public CommunicationTypeController(ICommunicationTypeRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }
    }
}
