using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class PageAccessController : GenericActivableAuthCompleteBaseController<PageAccess>
    {
        IPageAccessRepository _service;
        
        public PageAccessController(IPageAccessRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext ;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<Tuple<string,string>>> GetLinksForPage(string PageName)
        {
            return ResultProcessor.Process(() => _service.GetLinksForPage(PageName));
        }

        [HttpGet]
        public HttpResponseMessage CheckLink(string url)
        {
            if (_service.CheckLink(url) == true)
            {
                return new HttpResponseMessage (HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }


        [HttpGet]
        public ServiceResult<IEnumerable<PageAccess>> GetPageAccessForRole(int Id)
        {
            return ResultProcessor.Process(() => _service.GetPageAccessForRole(Id));
        }

        [HttpGet]
        public ServiceResult<IEnumerable<PageAccess>> GetPageAccess()
        {
            return ResultProcessor.Process(() => _service.GetPageAccess());
        }

        [HttpGet]
        public ServiceResult<bool> AddToAccess(int pagelinkid, int roleid)
        {
            return ResultProcessor.Process(() => _service.AddToAccess(pagelinkid, roleid));
        }

        [HttpGet]
        public ServiceResult<bool> RemoveFromAccess( int roleid, int pagelinkid)
        {
            return ResultProcessor.Process(() => _service.RemoveFromAccess(roleid,pagelinkid));
        }
   
    }
}

