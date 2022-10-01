using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.FileSystem;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class GroupToApplicationFileMappingController : GenericAuthCompleteBaseController<GroupToApplicationFileMapping>
    {
        public IGroupToApplicationFileMappingRepository _service;

        public GroupToApplicationFileMappingController(IGroupToApplicationFileMappingRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }
    }
}
