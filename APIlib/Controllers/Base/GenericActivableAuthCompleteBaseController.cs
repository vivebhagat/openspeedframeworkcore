using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{
    public class GenericActivableAuthCompleteBaseController<T> : GenericAuthCompleteBaseController<T> where T : class, IActivableEntity
    {
        public IGenericActivableRepository<T> _service;

        public GenericActivableAuthCompleteBaseController(IGenericActivableRepository<T> service):base(service)
        {
            _service = service;
        }


        [HttpGet]
        public ServiceResult<IEnumerable<T>> GetAllActive()
        {
            return ResultProcessor.Process<IEnumerable<T>>(() => _service.GetAllActive());
        }

        [HttpGet]
        public ServiceResult<bool> Activate(int Id)
        {
            return ResultProcessor.Process<bool>(() => _service.Activate(Id));
        }

        [HttpGet]
        public ServiceResult<bool> Deactivate(int Id)
        {
            return ResultProcessor.Process<bool>(() => _service.Deactivate(Id));
        }
    }
}
