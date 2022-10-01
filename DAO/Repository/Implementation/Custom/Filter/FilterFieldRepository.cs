using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class FilterFieldRepository : GenericActivableRepository<FilterField>, IFilterFieldRepository
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

        public FilterFieldRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }


        public IEnumerable<FilterField> GetForFilter(int Id)
        {
            return db.FilterFields.Where(m => m.CommonFilterId == Id).ToList();
        }

        public IEnumerable<object> GetFieldOperatorList()
        {
            var values = Enum.GetValues(typeof(FilterOperator));

            List<object> o = new List<object>();
            foreach (FilterOperator value in values)
            {
                o.Add(new { Id = (int)value, Name = value.ToString() });
            }

            return o;
        }



        public override void Validate(FilterField o)
        {
            CheckDuplicate(o, m=>o.Name==m.Name & o.CommonFilterId==m.CommonFilterId);
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }




        public override IQueryable<FilterField> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(FilterField o)
        {
        }

        public override void AfterAdd(FilterField o)
        {

        }

        public override void BeforeEdit(FilterField o)
        {
        }

        public override void AfterEdit(FilterField o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(FilterField t)
        {
            
        }
    }
 }
