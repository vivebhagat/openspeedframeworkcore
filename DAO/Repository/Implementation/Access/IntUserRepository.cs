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
    public class IntUserRepository : BaseUserRepository<IntUser>, IIntUserRepository
    {
        public override string entity_name
        {
            get { return "User"; }
            set { value = "User"; }
        }
        public override string entity_label
        {
            get { return "User"; }
            set { value = "User"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }
        public IntUserRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }


 


        public override void Validate(IntUser obj)
        {

            Dignos.CheckException(obj==null,StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(obj.FirstName),  StandardMessage.ERR_REQUIRED_FIELD.FormatError("FirstName"));
            Dignos.CheckException(String.IsNullOrEmpty(obj.LastName), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Last Name"));
            Dignos.CheckException(String.IsNullOrEmpty(obj.Email), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Email"));

            CheckDuplicate(obj, m => m.Name == obj.Name);

            int orgCount = db.Organizations.Where(m => m.Id == obj.OrgId).Count();
            Dignos.CheckException(orgCount != 1, String.Format(StandardMessage.ERR_ENTITY_NOT_EXIST, "Organisation"));

        }

        public override IQueryable<IntUser> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(IntUser t)
        {

        }

        public override void AfterAdd(IntUser t)
        {
        }

        public override void BeforeEdit(IntUser t)
        {
        }

        public override void AfterEdit(IntUser t)
        {

        }

        public void Dispose()
        {

        }

        public override void BeforeNavigationFieldBind(IntUser t)
        {
        }
    }
 }
