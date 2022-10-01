using SpeedFramework.DAO.Model.Access;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IOwnershipEntityAccessRepository : IGenericActivableRepository<OwnershipEntityAccess>
    {
        IEnumerable<OwnershipEntityAccess> GetForUser(int Id);
    }
}
