using SpeedFramework.DAO.Model.Custom.Entity;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IApplicationEntityPropertyRepository : IGenericRepository<ApplicationEntityProperty>
    {
        IEnumerable<ApplicationEntityProperty> GetForApplicationEntity(int Id);
    }
}
