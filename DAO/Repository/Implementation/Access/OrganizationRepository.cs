using Common.DAO.Access;
using Common.Helper;
using Common.Standard;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class OrganizationRepository : GenericActivableRepository<Organization>, IOrganizationRepository
    {
        public override string entity_name
        {
            get { return "Organization"; }
            set { value = "Organization"; }
        }
        public override string entity_label
        {
            get { return "Organization"; }
            set { value = "Organization"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public OrganizationRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }


        public override void Validate(Organization obj)
        {
            Dignos.CheckException(obj == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(obj.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(obj, m => m.Name == obj.Name);
        }


        public override IQueryable<Organization> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Organization t)
        {
        }

        public override void AfterAdd(Organization t)
        {
        }

        public override void BeforeEdit(Organization t)
        {

        }

        public override void AfterEdit(Organization t)
        {

        }

        public void Dispose()
        {

        }

        public Organization GetDefault()
        {
            return _set.Where(m => m.IsParent).FirstOrDefault();
        }

        public override void BeforeNavigationFieldBind(Organization t)
        {

        }
    }

}
