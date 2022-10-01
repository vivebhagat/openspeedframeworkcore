using System.Collections.Generic;
using System.Linq;
using Common.DAO.Access;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Custom.Scripting;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class EntityScriptRepository : GenericActivableRepository<EntityScript>, IEntityScriptRepository
    {
       

        public override string entity_name
        {
            get { return "Entity Script"; }
            set { value = "Entity Script"; }
        }
        public override string entity_label
        {
            get { return "Entity Script"; }
            set { value = "Entity Script"; }
        }


        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }



        public EntityScriptRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db,  userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(EntityScript o)
        {

        }

        public override IQueryable<EntityScript> GetAccessFilterdSet()
        {
            return _set;
        }

        public void Dispose()
        {
        }

      

        public override void BeforeAdd(EntityScript t)
        {
        }

        public override void AfterAdd(EntityScript t)
        {
        }

        public override void BeforeEdit(EntityScript t)
        {
        }

        public override void AfterEdit(EntityScript t)
        {
        }

        public override void BeforeNavigationFieldBind(EntityScript t)
        {

        }
    }

}
