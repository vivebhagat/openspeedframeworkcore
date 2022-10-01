using Common.DAO.Access;
using Common.Enum;
using Common.Standard;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace SpeedFramework.APILib.Controllers
{
    public class OrganizationController : GenericActivableAuthCompleteBaseController<Organization>
    {
        public IOrganizationRepository _service;

        public OrganizationController(IOrganizationRepository service, IUserContext userContext, IAccountContext accountContext) : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
        }

        [HttpGet]
        public ServiceResult<IEnumerable<Tuple<string, string>>> GetCurrencyList()
        {
            List<Tuple<string, string>> currencyList = new List<Tuple<string, string>>();
            currencyList.Add(new Tuple<string, string>("" + (int)CurrencyType.INR, Enum.GetName(typeof(CurrencyType), CurrencyType.INR)));
            currencyList.Add(new Tuple<string, string>("" + (int)CurrencyType.AUD, Enum.GetName(typeof(CurrencyType), CurrencyType.AUD)));
            currencyList.Add(new Tuple<string, string>("" + (int)CurrencyType.CHF, Enum.GetName(typeof(CurrencyType), CurrencyType.CHF)));
            currencyList.Add(new Tuple<string, string>("" + (int)CurrencyType.USD, Enum.GetName(typeof(CurrencyType), CurrencyType.USD)));

            return new ServiceResult<IEnumerable<Tuple<string, string>>> { Result = currencyList };
        }
        [HttpGet]
        public ServiceResult<Organization> GetDefualt()
        {
            return  ResultProcessor.Process(()=> _service.GetDefault());
        }
  
    }
}
