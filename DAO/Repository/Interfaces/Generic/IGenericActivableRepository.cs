using SpeedFramework.Common.CoreModels;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IGenericActivableRepository<T> : IGenericRepository<T> where T : class, IActivableEntity
    {
        IEnumerable<T> GetAllActive();
        bool Activate(int Id);
        bool Deactivate(int Id);
    }

}
