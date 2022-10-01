using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Filter;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Model.Custom.Entity;
using Microsoft.EntityFrameworkCore;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class FilterRepository : GenericActivableRepository<Filter>, IFilterRepository
    {
        public override string entity_name
        {
            get { return "Filter"; }
            set { value = "Filter"; }
        }
        public override string entity_label
        {
            get { return "Filter"; }
            set { value = "Filter"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FilterRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(Filter o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);

        }


        public IEnumerable<Filter> GetForEntity(int Id)
        {
            ApplicationEntity applicationEntity = db.ApplicationEntities.Where(m => m.Id == Id).FirstOrDefault();
            Dignos.CheckException(applicationEntity == null, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Entity"));
            IEnumerable<Filter> filters = db.Filters.Where(m => m.ApplicationEntityId == Id).ToList();
            return filters;
        }

        public FilterResult<dynamic> Filter(int Id, int s, int n)
        {
            FilterEngine fe = new FilterEngine();
            return fe.GetFilteredWithOffsetWrapper(Id, new List<FilterField>(), this.db,userContext, s, n);
        }


        public FilterResult<dynamic> _postFilter(int Id, IEnumerable<FilterField> filterFields, int s, int n)
        {
            FilterEngine fe = new FilterEngine();
            return fe.GetFilteredWithOffsetWrapper(Id, filterFields, this.db, userContext, s, n);
        }



        public override IQueryable<Filter> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Filter form)
        {
        }

        public override void AfterAdd(Filter t)
        {
            setDefaults(t);
        }

        private void setDefaults(Filter t)
        {
            if (t.IsDefault)
            {
                List<Filter> filters = db.Filters.Where(m => m.IsDefault & t.Id != m.Id).ToList();
                if (!(filters == null || filters.Count == 0))
                {
                    filters.ForEach(m => m.IsDefault = false);
                    db.GetDbContext().Entry(filters).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public override void BeforeEdit(Filter category)
        {
        }

        public override void AfterEdit(Filter t)
        {
            setDefaults(t);
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(Filter t)
        {
            
        }
    }
 }
