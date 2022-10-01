using Common.Filter;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{

    public class GenericAuthCompleteBaseController<T> : AuthCompleteBaseController where T : class, TEntity
    {
        public IGenericRepository<T> _service;

        public GenericAuthCompleteBaseController(IGenericRepository<T> service)
        {
            _service = service;
        }

        [HttpPost]
        public ServiceResult<int> Add(T o)
        {
            return ResultProcessor.Process<int>(() => _service.Add(o));
        }

        [HttpPost]
        public ServiceResult<Form> GetForm()
        {
            return ResultProcessor.Process<Form>(() => _service.GetForm());
        }

        [HttpGet]
        public ServiceResult<IEnumerable<CommunicationTemplate>> GetTemplates(int Id)
        {
            return ResultProcessor.Process<IEnumerable<CommunicationTemplate>>(() => _service.GetTemplates(Id));
        }


      /*  [HttpGet]
        public HttpResponseMessage Print(int templateId, int Id)
        {
            HttpResponseMessage result = null;
            try
            {

                string path =  _service.Print(templateId,Id);
                var dataBytes = File.ReadAllBytes(path);
                var dataStream = new MemoryStream(dataBytes);

                HttpResponseMessage httpResponseMessage = new HttpResponseMessage(); // Request.Body; // CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "test" + ".pdf";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

                return httpResponseMessage;
                
            }
            catch (Exception ex)
            {
                 HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                 httpResponseMessage.StatusCode = HttpStatusCode.Gone;
                 return httpResponseMessage;
            }
        }*/

        [HttpGet]
        public ServiceResult<ApplicationEntity> GetEntity()
        {
            return ResultProcessor.Process<ApplicationEntity>(() => _service.GetEntity());
        }

        [HttpGet]
        public ServiceResult<IEnumerable<T>> GetAll()
        {
            return ResultProcessor.Process<IEnumerable<T>>(() => _service.GetAll());
        }

        [HttpGet]
        public ServiceResult<T> Get(int Id)
        {
            return ResultProcessor.Process<T>(() => _service.Get(Id));
        }

        [HttpGet]
        public ServiceResult<T> GetByName(string name)
        {
            return ResultProcessor.Process<T>(() => _service.Get(name));
        }


        [HttpPost]
        public ServiceResult<bool> Edit(T o)
        {
            return ResultProcessor.Process<bool>(() => _service.Edit(o));
        }

        [HttpPut]
        public ServiceResult<bool> EditAction(T o, int Id)
        {
            return ResultProcessor.Process<bool>(() => _service.EditAction(o,Id));
        }

        [HttpPost]
        public ServiceResult<bool> _postEditAction(EditActionData<T> o)
        {
            return ResultProcessor.Process<bool>(() => _service.EditAction(o.Data, o.Id));
        }

        [HttpPut]
        public ServiceResult<FilterResult<T>> GetFiltered(int Id, IEnumerable<FilterField> filterFields, int s, int n)
        {
            return ResultProcessor.Process(() =>  _service.GetFiltered(Id, filterFields,_userContext,s,n));
        }

        [HttpPost]
        public ServiceResult<FilterResult<T>> _postGetFiltered(PostFilter postFilter)
        {
            return ResultProcessor.Process(() => _service.GetFiltered(postFilter.Id,
                postFilter.filterFields, _userContext, postFilter.s, postFilter.n));
        }

        [HttpPut]
        public ServiceResult<FilterResult<T>> GetUIFiltered(int? Id, string value, IEnumerable<FilterField> filterFields, int s, int n)
        {
            return ResultProcessor.Process(() =>  _service.GetUIFiltered( Id,  value, filterFields, _userContext, s,  n).Result);
        }

        [HttpPost]
        public ServiceResult<FilterResult<T>> _postGetUIFiltered(PostUIFilter postUIFilter)
        {
            return ResultProcessor.Process(() => _service.GetUIFiltered(postUIFilter.Id,
                postUIFilter.value, postUIFilter.filterFields, _userContext, postUIFilter.s, postUIFilter.n).Result);
        }



        [HttpGet]
        public ServiceResult<IEnumerable<StateActionStatement>> GetStateActionStatements(int Id)
        {
            return ResultProcessor.Process<IEnumerable<StateActionStatement>>(() => _service.GetStateActionStatements(Id));
        }

    }

    public class EditActionData<T> where T : TEntity
    {
        public T Data { get; set; }
        public int Id { get; set; }
    }

}
