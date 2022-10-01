using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{
    public class CommunicationTemplateController : GenericActivableAuthCompleteBaseController<CommunicationTemplate>
    {
        public ICommunicationTemplateRepository _service;

        public CommunicationTemplateController(ICommunicationTemplateRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<CommunicationTemplate>> GetForEntity(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForEntity(Id));
        }
    }
}
