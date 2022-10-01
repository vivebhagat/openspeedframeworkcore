using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class CustomPageRepository : GenericActivableRepository<CustomPage>, ICustomPageRepository
    {
        public override string entity_name
        {
            get { return "Custom Page"; }
            set { value = "Custom Page"; }
        }
        public override string entity_label
        {
            get { return "Custom Page"; }
            set { value = "Custom Page"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public CustomPageRepository(IModelContext db, IUserContext userContext,IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }



        public override void Validate(CustomPage o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);
        }

        public override IQueryable<CustomPage> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(CustomPage o)
        {
        }

        public override void AfterAdd(CustomPage o)
        {

        }

        public override void BeforeEdit(CustomPage o)
        {
        }

        public override void AfterEdit(CustomPage o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(CustomPage t)
        {
            
        }
    }

}
