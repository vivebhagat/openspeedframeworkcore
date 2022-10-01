using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Commmon;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class FieldTypeRepository : GenericActivableRepository<FieldType>, IFieldTypeRepository
    {
        public override string entity_name
        {
            get { return "Field Type"; }
            set { value = "Field Type"; }
        }
        public override string entity_label
        {
            get { return "Field Type"; }
            set { value = "Field Type"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FieldTypeRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }

   

        public override void Validate(FieldType o)
        {
            Dignos.CheckException(o==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);           
        }

        public override IQueryable<FieldType> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(FieldType form)
        {
        }

        public override void AfterAdd(FieldType t)
        {
 
        }

        public override void BeforeEdit(FieldType category)
        {
        }

        public override void AfterEdit(FieldType t)
        {
         
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(FieldType t)
        {
            
        }
    }
 }
