using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class OptionController : GenericActivableAuthCompleteBaseController<Option>
    {
        public IOptionRepository _service;

        public OptionController(IOptionRepository service, IUserContext userContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
        }


        [HttpGet]
        public ServiceResult<IEnumerable<Option>> GetForList(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForList(Id));
        }

    }
}
