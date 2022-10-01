using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IWidgetRepository : IGenericActivableRepository<Widget>
    {
        List<List<Widget>> GetForDashboard(int Id);
    }
}
