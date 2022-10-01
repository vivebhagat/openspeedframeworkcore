using Common.DAO.Access;
using Common.Standard;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{
    public class OwnershipEntityAccessController : GenericActivableAuthCompleteBaseController<OwnershipEntityAccess>
    {
        public IOwnershipEntityAccessRepository _service;

        public OwnershipEntityAccessController(IOwnershipEntityAccessRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        public ServiceResult<IEnumerable<OwnershipEntityAccess>> GetForUser(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForUser(Id));
        }
    }
}
