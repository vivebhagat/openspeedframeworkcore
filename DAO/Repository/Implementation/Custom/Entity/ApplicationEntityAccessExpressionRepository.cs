using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class ApplicationEntityAccessExpressionRepository : GenericActivableRepository<ApplicationEntityAccessExpression>, IApplicationEntityAccessExpressionRepository
    {
        public override string entity_name
        {
            get { return "Entity Access Expression"; }
            set { value = "Entity Access Expression"; }
        }
        public override string entity_label
        {
            get { return "Entity Access Expression"; }
            set { value = "Entity Access Expression"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public ApplicationEntityAccessExpressionRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
           
        }

        
        public override void Validate(ApplicationEntityAccessExpression o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

//            CheckDuplicate(o, m => m.Name == o.Name);
        }


        public IEnumerable<ApplicationEntityAccessExpression> GetForEntity(int Id)
        {
            return db.ApplicationEntityAccessExpressions.Where(m => m.ApplicationEntityId == Id & !m.Inactive).ToList();
        }

        public override IQueryable<ApplicationEntityAccessExpression> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(ApplicationEntityAccessExpression form)
        {
        }

        public override void AfterAdd(ApplicationEntityAccessExpression t)
        {
        }

        public override void BeforeEdit(ApplicationEntityAccessExpression category)
        {
        }

        public override void AfterEdit(ApplicationEntityAccessExpression t)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(ApplicationEntityAccessExpression t)
        {

        }
    }
}
