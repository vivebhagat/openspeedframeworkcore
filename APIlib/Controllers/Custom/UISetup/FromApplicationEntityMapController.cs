using Common.DAO.Access;
using Common.Standard;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class FormApplicationEntityMapController : GenericActivableAuthCompleteBaseController<FormApplicationEntityMap>
    {
        public IFormApplicationEntityMapRepository _service;

        public FormApplicationEntityMapController(IFormApplicationEntityMapRepository service, IUserContext userContext): base(service)
        {
            _service = service;
            _userContext = userContext;
        }

        public ServiceResult<IEnumerable<FormApplicationEntityMap>> GetAllForApplication(int Id)
        {
            return ResultProcessor.Process(() => _service.GetAllForApplication(Id));
        }

    }
}
