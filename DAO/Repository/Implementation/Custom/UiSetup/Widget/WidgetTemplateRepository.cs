using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class WidgetTemplateRepository : GenericActivableRepository<WidgetTemplate>, IWidgetTemplateRepository
    {
        public override string entity_name
        {
            get { return "Widget Template"; }
            set { value = "Widget Template"; }
        }
        public override string entity_label
        {
            get { return "Widget Template"; }
            set { value = "Widget Template"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public WidgetTemplateRepository(IModelContext db,  IUserContext userContext,IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(WidgetTemplate o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }

        public override IQueryable<WidgetTemplate> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(WidgetTemplate o)
        {
        }

        public override void AfterAdd(WidgetTemplate o)
        {

        }

        public override void BeforeEdit(WidgetTemplate o)
        {
        }

        public override void AfterEdit(WidgetTemplate o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(WidgetTemplate t)
        {

        }
    }

}
