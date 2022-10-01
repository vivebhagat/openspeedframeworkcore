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
    public class ServerDirectoryController : GenericAuthCompleteBaseController<ServerDirectory>
    {
        public IServerDirectoryRepository _service;

        public ServerDirectoryController(IServerDirectoryRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpPost]
        public ServiceResult<int> AddAndCreate(ServerDirectory o)
        {

            ServiceResult<int> result = ResultProcessor.Process(() => _service.Add(o));
            try
            {
                string root_directory = _accountContext.ServerDirectoryRoot; 

                if (String.IsNullOrEmpty(root_directory))
                    throw new DataProcessingException("Server storage is not configured.");

                string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, root_directory, o.FullPath);
                if (new DirectoryInfo(o.FullPath).Exists)
                {
                    throw new DataProcessingException("Directory already exists.");
                }
                DirectoryInfo d = Directory.CreateDirectory(directory);
            }
            catch(Exception e)
            {
                throw new DataProcessingException("Directory can not be created.");
            }
            return result;
        }

    }
}
