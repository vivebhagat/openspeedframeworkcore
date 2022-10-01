using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{

    public class ApplicationEntityController : GenericActivableAuthCompleteBaseController<ApplicationEntity>
    {
        public IApplicationEntityRepository _service;

        public ApplicationEntityController(IApplicationEntityRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<bool> LoadEntities()
        {
            return ResultProcessor.Process(() => _service.LoadEntities());
        }


    }

}
