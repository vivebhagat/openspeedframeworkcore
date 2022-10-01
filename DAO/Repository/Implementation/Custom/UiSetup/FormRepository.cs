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
    public class FormRepository : GenericActivableRepository<Form>, IFormRepository
    {
        public override string entity_name
        {
            get { return "Form"; }
            set { value = "Form"; }
        }
        public override string entity_label
        {
            get { return "Form"; }
            set { value = "Form"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FormRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

   

        public override void Validate(Form form)
        {
            Dignos.CheckException(form==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(form.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(form, m => m.Name == form.Name);           
        }

        public IEnumerable<Form> GetForEntity(int Id)
        {
            int _c = db.ApplicationEntities.Where(m => m.Id == Id).Count();
            Dignos.CheckException(_c == 0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Entity"));
            return _set.Where(m => m.ApplicationEntityId == Id).ToList();
        }
        

        public override IQueryable<Form> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Form form)
        {
        }

        public override void AfterAdd(Form t)
        {
 
        }

        public override void BeforeEdit(Form category)
        {
        }

        public override void AfterEdit(Form t)
        {
         
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(Form t)
        {
            
        }
    }
 }
