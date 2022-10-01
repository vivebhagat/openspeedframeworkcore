using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{

    public class OptionListController : GenericActivableAuthCompleteBaseController<OptionList>
    {
        public IOptionListRepository _service;
        public OptionListController(IOptionListRepository service, IUserContext userContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
        }

    }
}
