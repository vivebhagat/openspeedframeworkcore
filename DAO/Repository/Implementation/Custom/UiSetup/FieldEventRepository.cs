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
    public class FieldEventRepository : GenericRepository<FieldEvent>, IFieldEventRepository
    {
        public override string entity_name
        {
            get { return "Field Event"; }
            set { value = "Field Event"; }
        }
        public override string entity_label
        {
            get { return "Field Event"; }
            set { value = "Field Event"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FieldEventRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

   

        public override void Validate(FieldEvent o)
        {
            Dignos.CheckException(o==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));
            Dignos.CheckException(o.FieldId==0,StandardMessage.ERR_REQUIRED_FIELD.FormatError("Field"));

            int _c =  db.Fields.Where(m => m.Id == o.FieldId).Count();
            Dignos.CheckException(_c == 0, StandardMessage.ERR_REQUIRED_FIELD.FormatError("Field"));

            CheckDuplicate(o, m => m.Name == o.Name & m.FieldId == m.FieldId);           
        }



        public override IQueryable<FieldEvent> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(FieldEvent form)
        {
        }

        public override void AfterAdd(FieldEvent t)
        {
 
        }

        public override void BeforeEdit(FieldEvent category)
        {
        }

        public override void AfterEdit(FieldEvent t)
        {
         
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(FieldEvent t)
        {
            
        }
    }
 }
