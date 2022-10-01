using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.APILib.Models.Attributs;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class UserDefinedRoleController : AuthStageBaseController
    {
        IUserDefinedRoleRepository _service;

        public UserDefinedRoleController(IUserDefinedRoleRepository service, IUserContext userContext, IAccountContext accountContext)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<UserDefinedRole>> GetRoleMap()
        {
            return ResultProcessor.Process(() => _service.GetRoleMap());
        }

/*        [HttpGet]
        public ServiceResult<List<Tuple<string, object>>> GetOwnershipEntityAccessMap()
        {
            return ResultProcessor.Process(() => _service.GetOwnershipEntityAccessMap());
        }*/

        [HttpGet]
        public Task<IEnumerable<UserDefinedRoleToUserMap>> GetFullRoleMap(int Id)
        {
            return ResultProcessor.ProcessAsync(() => _service.GetFullRoleMap(Id));
        }

        [HttpGet]
        [TypeFilter(typeof(ClaimsAuthorization))]
        public ServiceResult<bool> UnmapUserFromRole(int userid, int roleid)
        {
            return ResultProcessor.Process(() => _service.UnmapUserFromRole(userid, roleid));
        }

        [HttpGet]
        [TypeFilter(typeof(ClaimsAuthorization))]
        public ServiceResult<bool> MapUserToRole(int userid, int roleid)
        {
            return ResultProcessor.Process(() => _service.MapUserToRole(userid, roleid));
        }

        [HttpPost]
        [TypeFilter(typeof(ClaimsAuthorization))]
        public ServiceResult<int> Add(UserDefinedRole role)
        {
            return ResultProcessor.Process(() => _service.Add(role));
        }

        [HttpPost]
        [TypeFilter(typeof(ClaimsAuthorization))]
        public ServiceResult<bool> Edit(UserDefinedRole role)
        {
            return ResultProcessor.Process(() => _service.Edit(role));
        }

        [HttpGet]
        [TypeFilter(typeof(ClaimsAuthorization))]
        public ServiceResult<UserDefinedRole> Get(int Id)
        {
            return ResultProcessor.Process(() => _service.Get(Id));
        }

        [HttpGet]
        [TypeFilter(typeof(ClaimsAuthorization))]
        public ServiceResult<IEnumerable<UserDefinedRole>> GetAll()
        {
            return ResultProcessor.Process(() => _service.GetAll());
        }
    }
}

