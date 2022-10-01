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
    public class WidgetParameterTypeRepository : GenericActivableRepository<WidgetParameterType>, IWidgetParameterTypeRepository
    {
        public override string entity_name
        {
            get { return "Widget Parameter Type"; }
            set { value = "Widget Parameter Type"; }
        }
        public override string entity_label
        {
            get { return "Widget Parameter Type"; }
            set { value = "Widget Parameter Type"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public WidgetParameterTypeRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(WidgetParameterType o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }

        public override IQueryable<WidgetParameterType> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(WidgetParameterType o)
        {
        }

        public override void AfterAdd(WidgetParameterType o)
        {

        }

        public override void BeforeEdit(WidgetParameterType o)
        {
        }

        public override void AfterEdit(WidgetParameterType o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(WidgetParameterType t)
        {

        }
    }

}
