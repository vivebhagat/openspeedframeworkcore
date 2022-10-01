using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Commmon;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class OptionRepository : GenericActivableRepository<Option>, IOptionRepository
    {
        public override string entity_name
        {
            get { return "Option"; }
            set { value = "Option"; }
        }
        public override string entity_label
        {
            get { return "Option"; }
            set { value = "Option"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public OptionRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(Option o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);
        }

        public override IQueryable<Option> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Option o)
        {
        }

        public override void AfterAdd(Option o)
        {

        }

        public override void BeforeEdit(Option o)
        {
        }

        public override void AfterEdit(Option o)
        {

        }

        public void Dispose()
        {
        }

        public IEnumerable<Option> GetForList(int Id)
        {
            int _count = db.OptionLists.Where(m => m.Id == Id).Count();
            Dignos.CheckException(_count == 0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("List"));
            IEnumerable<Option> options = db.Options.Where(m => m.OptionListId == Id).ToList();
            return options;
        }

        public override void BeforeNavigationFieldBind(Option t)
        {

        }
    }

}
