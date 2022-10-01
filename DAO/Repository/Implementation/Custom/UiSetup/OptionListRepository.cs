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
    public class OptionListRepository : GenericActivableRepository<OptionList>, IOptionListRepository
    {
        public override string entity_name
        {
            get { return "Option List"; }
            set { value = "Option List"; }
        }
        public override string entity_label
        {
            get { return "Option List"; }
            set { value = "Option List"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public OptionListRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

   

        public override void Validate(OptionList o)
        {
            Dignos.CheckException(o==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            Dignos.CheckException(o.FieldId == 0, StandardMessage.ERR_REQUIRED_FIELD.FormatError("Field"));


            int _c = db.Fields.Where(m => m.Id == o.FieldId).Count();

            Dignos.CheckException(_c == 0, StandardMessage.ERR_REQUIRED_FIELD.FormatError("Field"));

            string fieldTypename = db.Fields.Where(m => m.Id == o.FieldId).FirstOrDefault().FieldType.Name;

            Dignos.CheckException(fieldTypename != "DROPDOWN", StandardMessage.ERR_ENTITY_INVALID.FormatError("Field Type"));
            
            CheckDuplicate(o, m => m.Name == o.Name);           
        }

        public override IQueryable<OptionList> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(OptionList o)
        {
        }

        public override void AfterAdd(OptionList o)
        {
 
        }

        public override void BeforeEdit(OptionList o)
        {
        }

        public override void AfterEdit(OptionList o)
        {
         
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(OptionList t)
        {
        }
    }

}
