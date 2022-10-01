using Common.DAO.Access;
using Common.Exceptions;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.FileSystem;
using SpeedFramework.DAO.Repository.Interfaces;
using System;
using System.IO;

namespace SpeedFramework.APILib.Controllers
{

    public class ApplicationFileController : GenericAuthCompleteBaseController<ApplicationFile>
    {
        public IApplicationFileRepository _service;

        public ApplicationFileController(IApplicationFileRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }


        /*
        [HttpPost]
        public ServiceResult<bool> AddWithFile()
        {
            try
            {
                var httpRequest = HttpContext.Request;
                string file_directory = _accountContext.ServerDirectoryRoot; // ConfigurationManager.AppSettings["ServerDirectoryRoot"].ToString();
                if (String.IsNullOrEmpty(file_directory))
                    throw new DataProcessingException("Server Storage is not configured.");

                if (httpRequest.Files.Count > 0)
                {
                    int i = Int32.Parse(httpRequest.Files[0].FileName);

                    ApplicationFile f = _service.Get(i);

                    string file_dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file_directory, f.ServerDirectory.FullPath);
                    httpRequest.Files[0].SaveAs(Path.Combine(file_dir, f.ResourceUri));
                }
                else {
                    throw new DataProcessingException("No data recieved.");
                }
            }
            catch(Exception e)
            {
                throw new DataProcessingException("File can not be stored. "+e.Message);
            }
            return new ServiceResult<bool> { Result=true }; 
        }*/
    }
}
