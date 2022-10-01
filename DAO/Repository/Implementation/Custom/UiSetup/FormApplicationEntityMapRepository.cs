using System.Collections.Generic;
using System.Linq;
using System;
using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class FormApplicationEntityMapRepository : GenericActivableRepository<FormApplicationEntityMap>, IFormApplicationEntityMapRepository
    {
       
        public override string entity_name
        {
            get { return "Form Field"; }
            set { value = "Form Field"; }
        }
        public override string entity_label
        {
            get { return "Form Field"; }
            set { value = "Form Field"; }
        }


        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FormApplicationEntityMapRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(FormApplicationEntityMap o)
        {

        }

        public override IQueryable<FormApplicationEntityMap> GetAccessFilterdSet()
        {
            return _set;
        }

        public void Dispose()
        {
        }

        public override void BeforeAdd(FormApplicationEntityMap t)
        {
        }

        public override void AfterAdd(FormApplicationEntityMap t)
        {
        }

        public override void BeforeEdit(FormApplicationEntityMap t)
        {
        }

        public override void AfterEdit(FormApplicationEntityMap t)
        {
        }

        public IEnumerable<FormApplicationEntityMap> GetAllForApplication(int id)
        {
            throw new NotImplementedException();
        }

        public override void BeforeNavigationFieldBind(FormApplicationEntityMap t)
        {
        }
    }

}
