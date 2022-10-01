using System.Collections.Generic;
using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class  UserDefinedRoleToUserMapController : GenericActivableAuthCompleteBaseController<UserDefinedRoleToUserMap>
    {
        IUserDefinedRoleToUserMapRepository _service;

        public UserDefinedRoleToUserMapController(IUserDefinedRoleToUserMapRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<UserDefinedRoleToUserMap>> GetForUser(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForUser(Id));
        }
    }
}

