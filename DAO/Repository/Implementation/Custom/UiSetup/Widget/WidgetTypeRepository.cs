using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class WidgetTypeRepository : GenericActivableRepository<WidgetType>, IWidgetTypeRepository
    {
        public override string entity_name
        {
            get { return "Widget Type"; }
            set { value = "Widget Type"; }
        }
        public override string entity_label
        {
            get { return "Widget Type"; }
            set { value = "Widget Type"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public WidgetTypeRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(WidgetType o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }

        public override IQueryable<WidgetType> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(WidgetType o)
        {
        }

        public override void AfterAdd(WidgetType o)
        {

        }

        public override void BeforeEdit(WidgetType o)
        {
        }

        public override void AfterEdit(WidgetType o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(WidgetType t)
        {

        }
    }

}
