using Common.DAO.Access;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SpeedFramework.APILib.Controllers
{

    public class PageLinkController : GenericActivableAuthCompleteBaseController<PageLink>
    {
        IPageLinkRepository _service;

        public PageLinkController(IPageLinkRepository service, IUserContext userContext):base(service)
        {
            _service = service;
            _userContext = userContext;
        }


        [HttpGet]
        public ServiceResult<bool> GetUIControllers()
        {

            IList<Tuple<string, string>> _result = new List<Tuple<string, string>>();
            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            List<Type> all_types = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    all_types.AddRange(assembly.GetTypes().Where(m => m.BaseType == typeof(ControllerBase)).ToList());
                }
                catch (Exception _e)
                {
                }
            }

            foreach (Type types in all_types)
            {

                var methods = types.GetMethods().ToList().Where(m => m.ReturnType == typeof(IActionResult)).ToList();
                foreach (MethodInfo methodInfo in methods)
                {
                    Tuple<string, string> s =
                        new Tuple<string, string>(types.Name.Replace("Controller", ""), methodInfo.Name);
                    _result.Add(s);
                }

            }            
            return ResultProcessor.Process(()=> _service.LoadUILinks(_result));
        }

    }
}

