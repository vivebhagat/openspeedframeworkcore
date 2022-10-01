using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Commmon;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class WidgetParameterRepository : GenericActivableRepository<WidgetParameter>, IWidgetParameterRepository
    {
        public override string entity_name
        {
            get { return "Widget Parameter"; }
            set { value = "Widget Parameter"; }
        }
        public override string entity_label
        {
            get { return "Widget Parameter"; }
            set { value = "Widget Parameter"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public WidgetParameterRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(WidgetParameter o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }

        public override IQueryable<WidgetParameter> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(WidgetParameter o)
        {
        }

        public override void AfterAdd(WidgetParameter o)
        {

        }

        public override void BeforeEdit(WidgetParameter o)
        {
        }

        public override void AfterEdit(WidgetParameter o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(WidgetParameter t)
        {
        }
    }

}
