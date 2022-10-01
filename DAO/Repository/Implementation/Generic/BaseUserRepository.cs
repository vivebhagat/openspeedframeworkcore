using Common.DAO.Access;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public abstract class BaseUserRepository<T> : GenericRepository<T>, IBaseIntUserRepository<T> where T : class, IBaseIntUser
    {
        public BaseUserRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext):base(db,userContext, accountContext)
        {
            _entityName = typeof(T).AssemblyQualifiedName;
            this.db = db;
            this.userContext = userContext;
            _set = db.GetDbContext().Set<T>();
          //  Getlabels();
        }

        public IEnumerable<IntUser> GetUsersByRoleId(int Id)
        {
            return db.UserDefinedRoleToUserMaps.Where(m => m.RoleId == Id).Select(m => m.IntUser).ToList();
        }
    }

}