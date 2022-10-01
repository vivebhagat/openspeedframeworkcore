using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{

    public class FormEventController : GenericAuthCompleteBaseController<FormEvent>
    {
        public IFormEventRepository _service;

        public FormEventController(IFormEventRepository service, IUserContext userContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
        }

    }
}
