using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.FileSystem;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class ApplicationFileTypeController : GenericAuthCompleteBaseController<ApplicationFileType>
    {
        public IApplicationFileTypeRepository _service;

        public ApplicationFileTypeController(IApplicationFileTypeRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }
    }
}
