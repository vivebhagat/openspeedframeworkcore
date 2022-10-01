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
    public class FormEventRepository : GenericRepository<FormEvent>, IFormEventRepository
    {
        public override string entity_name
        {
            get { return "Form Event"; }
            set { value = "Form Event"; }
        }
        public override string entity_label
        {
            get { return "Form Event"; }
            set { value = "Form Event"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FormEventRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }

   

        public override void Validate(FormEvent o)
        {
            Dignos.CheckException(o==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));
            Dignos.CheckException(o.FormId==0,StandardMessage.ERR_REQUIRED_FIELD.FormatError("Form"));

            int _c =  db.Fields.Where(m => m.Id == o.FormId).Count();
            Dignos.CheckException(_c == 0, StandardMessage.ERR_REQUIRED_FIELD.FormatError("Form"));

            CheckDuplicate(o, m => m.Name == o.Name & m.FormId == m.FormId);           
        }



        public override IQueryable<FormEvent> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(FormEvent form)
        {
        }

        public override void AfterAdd(FormEvent t)
        {
 
        }

        public override void BeforeEdit(FormEvent category)
        {
        }

        public override void AfterEdit(FormEvent t)
        {
         
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(FormEvent t)
        {
            
        }
    }
 }
