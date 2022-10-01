using SpeedFramework.DAO.Core.Model.UiSetup;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IFormApplicationEntityMapRepository : IGenericActivableRepository<FormApplicationEntityMap>
    {
        IEnumerable<FormApplicationEntityMap> GetAllForApplication(int id);
    }
}
