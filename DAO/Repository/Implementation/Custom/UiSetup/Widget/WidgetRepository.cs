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
    public class WidgetRepository : GenericActivableRepository<Widget>, IWidgetRepository
    {
        public override string entity_name
        {
            get { return "Widget"; }
            set { value = "Widget"; }
        }
        public override string entity_label
        {
            get { return "Widget"; }
            set { value = "Widget"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public WidgetRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(Widget o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }

        public override IQueryable<Widget> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Widget o)
        {
        }

        public override void AfterAdd(Widget o)
        {

        }

        public override void BeforeEdit(Widget o)
        {
        }

        public override void AfterEdit(Widget o)
        {

        }

        public List<List<Widget>> GetForDashboard(int Id)
        {
            List<Widget> widgets = db.Widgets.Where(m => m.DashboardId == Id).ToList();
            List<int> widget_rows = widgets.OrderBy(m=>m.Row).Select(m => m.Row).Distinct().ToList();

            List<List<Widget>> uiWidgets = new List<List<Widget>>();

            foreach (int row in widget_rows)
            {
                List<Widget> rowWidgets = widgets.Where(m => m.Row == row).OrderBy(m => m.Index).ToList();
                uiWidgets.Add(rowWidgets);
            }

            return uiWidgets;
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(Widget t)
        {

        }
    }

}
