using SpeedFramework.DAO.Model.Access;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IBaseIntUserRepository<T> : IGenericRepository<T> where T : class, IBaseIntUser
    {
        IEnumerable<IntUser> GetUsersByRoleId(int Id);
    }

}
