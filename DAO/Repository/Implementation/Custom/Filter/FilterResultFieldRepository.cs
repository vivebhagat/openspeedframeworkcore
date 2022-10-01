using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class FilterResultFieldRepository : GenericActivableRepository<FilterResultField>, IFilterResultFieldRepository
    {
        public override string entity_name
        {
            get { return "Filter Field"; }
            set { value = "Filter Field"; }
        }
        public override string entity_label
        {
            get { return "Filter Field"; }
            set { value = "Filter Field"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FilterResultFieldRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }

        public IEnumerable<FilterResultField> GetForFilter(int Id)
        {
            return _set.Where(m => m.CommonFilterId == Id).ToList();
        }

        public override void Validate(FilterResultField o)
        {
            CheckDuplicate(o, m=>o.Name==m.Name & o.CommonFilterId==m.CommonFilterId);
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }

        public override IQueryable<FilterResultField> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(FilterResultField o)
        {
        }

        public override void AfterAdd(FilterResultField o)
        {

        }

        public override void BeforeEdit(FilterResultField o)
        {
        }

        public override void AfterEdit(FilterResultField o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(FilterResultField t)
        {
        }
    }
 }
