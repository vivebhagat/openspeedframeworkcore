using System.Collections.Generic;
using System.Linq;
using Common.DAO.Access;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class FormFieldMapRepository : GenericActivableRepository<FormFieldMap>, IFormFieldMapRepository
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

       
        public FormFieldMapRepository(IModelContext db,  IUserContext userContext,IAccountContext accountContext) :base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }

   

        public override void Validate(FormFieldMap o)
        {
        
        }

        public override IQueryable<FormFieldMap> GetAccessFilterdSet()
        {
            return _set;
        }

        public void Dispose()
        {
        }

        public override void BeforeAdd(FormFieldMap t)
        {
        }

        public override void AfterAdd(FormFieldMap t)
        {
        }

        public override void BeforeEdit(FormFieldMap t)
        {
        }

        public override void AfterEdit(FormFieldMap t)
        {
        }

        public IEnumerable<FormFieldMap> GetAllForForm(int id)
        {
            return db.FormFieldMaps.Where(m => m.FormId == id).ToList();
        }

        public override void BeforeNavigationFieldBind(FormFieldMap t)
        {
        }
    }

}
