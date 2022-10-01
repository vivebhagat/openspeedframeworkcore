using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{

    public class StateActionRepository : GenericActivableRepository<StateAction>, IStateActionRepository
    {
        public override string entity_name
        {
            get { return "State Action"; }
            set { value = "State Action"; }
        }
        public override string entity_label
        {
            get { return "State Action"; }
            set { value = "State Action"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public StateActionRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }



        public override void Validate(StateAction o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name & m.ApplicationEntityId == o.ApplicationEntityId);
        }

        public IEnumerable<StateAction> GetForEntity(int Id)
        {
            int c = db.ApplicationEntities.Where(m => m.Id == Id).Count();
            Dignos.CheckException(c == 0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Entity"));

            List<StateAction> actions = _set.Where(m => m.ApplicationEntityId == Id).ToList();
            return actions;
        }


        public override IQueryable<StateAction> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(StateAction form)
        {
        }

        public override void AfterAdd(StateAction t)
        {

        }

        public override void BeforeEdit(StateAction category)
        {
        }

        public override void AfterEdit(StateAction t)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(StateAction t)
        {
            
        }
    }
 }
