using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class StateActionStatementRepository : GenericActivableRepository<StateActionStatement>, IStateActionStatementRepository
    {
        public override string entity_name
        {
            get { return "StateAction Statement"; }
            set { value = "StateAction Statement"; }
        }
        public override string entity_label
        {
            get { return "StateAction Statement"; }
            set { value = "StateAction Statement"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public StateActionStatementRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }



        public override void Validate(StateActionStatement o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            CheckDuplicate(o, m => m.StateActionId == o.StateActionId & m.ApplicationEntityPropertyId == o.ApplicationEntityPropertyId & m.currentValue==o.currentValue & m.nextValue==o.nextValue);

        }




        public override IQueryable<StateActionStatement> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(StateActionStatement form)
        {
        }

        public override void AfterAdd(StateActionStatement t)
        {

        }

        public override void BeforeEdit(StateActionStatement category)
        {
        }

        public override void AfterEdit(StateActionStatement t)
        {

        }

        public void Dispose()
        {
        }

        public IEnumerable<StateActionStatement> GetForStateAction(int id)
        {
            IEnumerable<StateActionStatement> actions = db.StateActionStatements.Where(m => m.StateActionId == id).ToList();
            return actions;
        }

        public override void BeforeNavigationFieldBind(StateActionStatement t)
        {

        }
    }
 }
