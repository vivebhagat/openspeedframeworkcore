using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Custom.Entity;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IApplicationEntityRepository : IGenericActivableRepository<ApplicationEntity>
    {
        Form GetPreferredForm(int Id);
        bool LoadEntities();
    }
}
