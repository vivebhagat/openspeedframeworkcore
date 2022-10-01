using System;
using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.Exceptions;
using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{

    public class DashboardRepository : GenericActivableRepository<Dashboard>, IDashboardRepository
    {
        public override string entity_name
        {
            get { return "Dashboard"; }
            set { value = "Dashboard"; }
        }
        public override string entity_label
        {
            get { return "Dashboard"; }
            set { value = "Dashboard"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }
        public DashboardRepository(IModelContext db,  IUserContext userContext,IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }
 


        public Dashboard GetQuickDashboard()
        {
            Dashboard d = db.Dashboards.Where(m=>m.Name=="Default").FirstOrDefault();
            if (d == null)
            {
                try
                {
                    d = new Dashboard { Name="Default"};
                    db.SetStateAsAdded(d);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DataProcessingException("No quickboard configured.");
                }
            }
            return d;
        }

   
      

        public override void Validate(Dashboard d)
        {

            Dignos.CheckException(d == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(d.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));
            CheckDuplicate(d, m => m.Name == d.Name);

        }

        public override IQueryable<Dashboard> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Dashboard t)
        {

        }

        public override void AfterAdd(Dashboard t)
        {
        }

        public override void BeforeEdit(Dashboard t)
        {
        }

        public override void AfterEdit(Dashboard t)
        {
        }

        public override void BeforeNavigationFieldBind(Dashboard t)
        {
            
        }
    }
}