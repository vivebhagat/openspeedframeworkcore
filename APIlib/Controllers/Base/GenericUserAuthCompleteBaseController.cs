using Common.Exceptions;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpeedFramework.APILib.Models.Authentication;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpeedFramework.APILib.Controllers
{
    public class GenericUserAuthCompleteBaseController<T> : GenericAuthCompleteBaseController<T> where T : class, IBaseIntUser
    {
        public IBaseIntUserRepository<T> _service;

        public GenericUserAuthCompleteBaseController(IBaseIntUserRepository<T> service): base(service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Register(T intUser)
        {
            _service.Validate(intUser);
            Models.Authentication.UserModel userModel = new Models.Authentication.UserModel
            {
                
                UserName = intUser.Name,
                Email = intUser.Email,
                Password = intUser.Password,
                ConfirmPassword = intUser.Password,
            };
            string IS_AUTH_LOCAL = "true";//ConfigurationManager.AppSettings["IS_AUTH_LOCAL"];
            if (!String.IsNullOrEmpty(IS_AUTH_LOCAL) && IS_AUTH_LOCAL == "true")
            {
                AuthRepository authRepository = new AuthRepository();

                string result = await authRepository.RegisterUserId(userModel);

                intUser.UserId = result;

                try
                {
                    return _service.Add(intUser);
                }
                catch (Exception e)
                {
                    return -1;
                }

            }
            else
            {
                string AUTH_URL = ""; // ConfigurationManager.AppSettings["AUTH_URL"];
                if (!String.IsNullOrEmpty(AUTH_URL))
                {
                    WebClient httpClient = new WebClient();
                    string userModelString = JsonConvert.SerializeObject(userModel);
                    var content = new StringContent(userModelString, Encoding.UTF8, "application/json");
                    string Id = httpClient.UploadString(AUTH_URL, "POST", userModelString);

                    intUser.UserId = Id;
                    return _service.Add(intUser);
                }
                else
                {
                    throw new DataProcessingException("Registration Unsuccessful.");
                }
            }
        }


        public async Task<bool> UpdateLoginData(T intUser)
        {
            _service.Validate(intUser);
            Models.Authentication.UserModel userModel = new Models.Authentication.UserModel
            {
                UserName = intUser.Name,
                Password = intUser.Password,
                ConfirmPassword = intUser.Password,
            };

            string IS_AUTH_LOCAL = "true"; // ConfigurationManager.AppSettings["IS_AUTH_LOCAL"];
            if (!String.IsNullOrEmpty(IS_AUTH_LOCAL) && IS_AUTH_LOCAL == "true")
            {
                AuthRepository authRepository = new AuthRepository();
                bool result = await authRepository.UpdateLoginData(userModel);
                return result;
            }
            else
            {
                string AUTH_URL = "true"; // ConfigurationManager.AppSettings["AUTH_OVERRIDE_URL"];
                if (!String.IsNullOrEmpty(AUTH_URL))
                {
/*                    WebClient httpClient = new WebClient();
                    string userModelString = JsonConvert.SerializeObject(userModel);
                    var content = new StringContent(userModelString, Encoding.UTF8, "application/json");
                    string Id = httpClient.UploadString(AUTH_URL, "POST", userModelString);

                    intUser.UserId = Id;*/
                    return false;
                }
                else
                {
                    throw new DataProcessingException("Update Unsuccessful.");
                }
            }

        }

        [HttpGet]
        public ServiceResult<IEnumerable<IntUser>> GetUsersByRoleId(int Id)
        {
            return ResultProcessor.Process(() => _service.GetUsersByRoleId(Id));
        }

    }
}
