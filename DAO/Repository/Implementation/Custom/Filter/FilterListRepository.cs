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
    public class FilterListRepository : GenericActivableRepository<FilterList>, IFilterListRepository
    {
        public override string entity_name
        {
            get { return "Filter List"; }
            set { value = "Filter List"; }
        }
        public override string entity_label
        {
            get { return "Filter List"; }
            set { value = "Filter List"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FilterListRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

   

        public override void Validate(FilterList o)
        {
            Dignos.CheckException(o==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);           
        }

        public override IQueryable<FilterList> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(FilterList form)
        {
        }

        public override void AfterAdd(FilterList t)
        {
 
        }

        public override void BeforeEdit(FilterList category)
        {
        }

        public override void AfterEdit(FilterList t)
        {
         
        }

        public void Dispose()
        {
        }

        public IEnumerable<object> LoadForFilterField(int id, int s, int n)
        {
            int filterId = db.FilterLists.Where(m => m.FilterFieldId == id).Select(m => m.FilterId).FirstOrDefault();
            FilterEngine fe = new FilterEngine();
            return fe.GetFilteredWrapper(filterId, new FilterField[] { }, db,userContext, s, n);
        }

        public override void BeforeNavigationFieldBind(FilterList t)
        {
            
        }
    }
 }
