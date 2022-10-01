using Common.DAO.Access;
using Common.Standard;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{
    public class ApplicationEntityAccessExpressionController : GenericActivableAuthCompleteBaseController<ApplicationEntityAccessExpression>
    {
        public IApplicationEntityAccessExpressionRepository _service;

        public ApplicationEntityAccessExpressionController(IApplicationEntityAccessExpressionRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        public ServiceResult<IEnumerable<ApplicationEntityAccessExpression>> GetForEntity(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForEntity(Id));
        }
    }
}
