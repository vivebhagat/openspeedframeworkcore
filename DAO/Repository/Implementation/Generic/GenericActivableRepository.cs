using Common.DAO.Access;
using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public abstract class GenericActivableRepository<T> : GenericRepository<T>, IGenericActivableRepository<T> where T : class, IActivableEntity
    {
        public GenericActivableRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
            _set = db.GetDbContext().Set<T>();
            Getlabels();
        }


        public IEnumerable<T> GetAllActive()
        {
            return GetAccessFilterdSet().Where(m => !m.Inactive).ToList();
        }

        public bool Activate(int Id)
        {
            var entity = GetAccessFilterdSet().Where(m => m.Id == Id).FirstOrDefault();
            entity.Inactive = false;
            return this.Edit(entity);
            
        }

        public bool Deactivate(int Id)
        {
            var entity = GetAccessFilterdSet().Where(m => m.Id == Id).FirstOrDefault();
            entity.Inactive = true;
            return this.Edit(entity);
        }

    }

}