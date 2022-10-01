using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{
    public class CommunicationTemplateUserRecieverMapController : GenericActivableAuthCompleteBaseController<CommunicationTemplateUserRecieverMap>
    {
        public ICommunicationTemplateUserRecieverMapRepository _service;

        public CommunicationTemplateUserRecieverMapController(ICommunicationTemplateUserRecieverMapRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<CommunicationTemplateUserRecieverMap>> GetForTemplate(int Id)
        {
            return ResultProcessor.Process(() => _service.GetForTemplate(Id));
        }
    }
}
