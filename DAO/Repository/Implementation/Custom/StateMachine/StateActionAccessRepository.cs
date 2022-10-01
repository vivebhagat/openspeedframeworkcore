using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Commmon;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class StateActionAccessRepository : GenericActivableRepository<StateActionAccess>, IStateActionAccessRepository
    {
        public override string entity_name
        {
            get { return "StateAction Access"; }
            set { value = "StateAction Access"; }
        }
        public override string entity_label
        {
            get { return "StateAction Access"; }
            set { value = "StateAction Access"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public StateActionAccessRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }



        public override void Validate(StateActionAccess o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }



        public override IQueryable<StateActionAccess> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(StateActionAccess form)
        {
        }

        public override void AfterAdd(StateActionAccess t)
        {

        }

        public override void BeforeEdit(StateActionAccess category)
        {
        }

        public override void AfterEdit(StateActionAccess t)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(StateActionAccess t)
        {

        }
    }
 }
