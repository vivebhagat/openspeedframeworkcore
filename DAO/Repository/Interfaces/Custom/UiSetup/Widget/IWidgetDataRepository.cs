using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IWidgetDataRepository : IGenericActivableRepository<WidgetData>
    {
        Dictionary<string, object> GetWidgetData(int Id, int widgetId);
    }
}
