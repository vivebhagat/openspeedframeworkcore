using Common.DAO.Access;
using Common.Standard;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class FormFieldMapController : GenericActivableAuthCompleteBaseController<FormFieldMap>
    {
        public IFormFieldMapRepository _service;

        public FormFieldMapController(IFormFieldMapRepository service, IUserContext userContext): base(service)
        {
            _service = service;
            _userContext = userContext;
        }

        public ServiceResult<IEnumerable<FormFieldMap>> GetAllForForm(int Id)
        {
            return ResultProcessor.Process(() => _service.GetAllForForm(Id));
        }
    }
}
