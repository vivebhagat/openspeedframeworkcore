using SpeedFramework.DAO.Model.Access;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IUserDefinedRoleToUserMapRepository : IGenericActivableRepository<UserDefinedRoleToUserMap>
    {
        IEnumerable<UserDefinedRoleToUserMap> GetForUser(int Id);
    }
}