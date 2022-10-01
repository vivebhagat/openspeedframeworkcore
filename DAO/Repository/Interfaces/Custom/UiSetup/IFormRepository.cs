using SpeedFramework.DAO.Core.Model.UiSetup;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IFormRepository : IGenericActivableRepository<Form>
    {
        IEnumerable<Form> GetForEntity(int Id);
    }
}
