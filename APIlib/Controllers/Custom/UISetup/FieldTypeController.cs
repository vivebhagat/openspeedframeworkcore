using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{

    public class FieldTypeController : GenericActivableAuthCompleteBaseController<FieldType>
    {
        public IFieldTypeRepository _service;

        public FieldTypeController(IFieldTypeRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

    }
}
