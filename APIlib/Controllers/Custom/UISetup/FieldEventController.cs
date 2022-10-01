using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{

    public class FieldEventController : GenericAuthCompleteBaseController<FieldEvent>
    {
        public IFieldEventRepository _service;

        public FieldEventController(IFieldEventRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

    }
}
