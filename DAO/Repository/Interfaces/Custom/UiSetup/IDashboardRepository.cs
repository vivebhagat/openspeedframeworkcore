using SpeedFramework.DAO.Core.Model.UiSetup;

namespace SpeedFramework.DAO.Repository.Interfaces
{

    public interface IDashboardRepository : IGenericActivableRepository<Dashboard>
    { 
        Dashboard GetQuickDashboard();
    }
}
