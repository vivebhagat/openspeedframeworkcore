using Common.DAO.Access;
using Common.Helper;
using Common.Standard;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class OwnershipEntityAccessRepository : GenericActivableRepository<OwnershipEntityAccess>, IOwnershipEntityAccessRepository
    {
        public override string entity_name
        {
            get { return "Ownership Entity Access"; }
            set { value = "Ownership Entity Access"; }
        }
        public override string entity_label
        {
            get { return "Ownership Entity Access"; }
            set { value = "Ownership Entity Access"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }
        public OwnershipEntityAccessRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }


        public override void Validate(OwnershipEntityAccess obj)
        {
            Dignos.CheckException(obj == null, StandardMessage.ERR_NO_DETAILS);
        }

        public IEnumerable<OwnershipEntityAccess> GetForUser(int Id)
        {
            return db.OwnershipEntityAccesses.Where(m => m.IntUserId == Id ).ToList();    
        }


        public override IQueryable<OwnershipEntityAccess> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(OwnershipEntityAccess t)
        {
        }

        public override void AfterAdd(OwnershipEntityAccess t)
        {
        }

        public override void BeforeEdit(OwnershipEntityAccess t)
        {

        }

        public override void AfterEdit(OwnershipEntityAccess t)
        {

        }

        public void Dispose()
        {

        }

        public override void BeforeNavigationFieldBind(OwnershipEntityAccess t)
        {
        }
    }

}
