using System.Collections.Generic;
using System.Linq;
using Common.DAO.Access;
using Common.Helper;
using Common.Standard;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class UserDefinedRoleToUserMapRepository : GenericActivableRepository<UserDefinedRoleToUserMap>, IUserDefinedRoleToUserMapRepository
    {
        public override string entity_name
        {
            get { return "Role To User Map"; }
            set { value = "Role To User Map"; }
        }
        public override string entity_label
        {
            get { return "Role To User Map"; }
            set { value = "Role To User Map"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }


        public UserDefinedRoleToUserMapRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }




        public override void Validate(UserDefinedRoleToUserMap o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            CheckDuplicate(o, m => m.IntUserId == o.IntUserId & m.RoleId==o.RoleId );
        }

        public override IQueryable<UserDefinedRoleToUserMap> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(UserDefinedRoleToUserMap o)
        {
        }

        public override void AfterAdd(UserDefinedRoleToUserMap o)
        {
        }

        public override void BeforeEdit(UserDefinedRoleToUserMap o)
        {

        }

        public override void AfterEdit(UserDefinedRoleToUserMap o)
        {
        }

        public IEnumerable<UserDefinedRoleToUserMap> GetForUser(int Id)
        {
            return db.UserDefinedRoleToUserMaps.Where(m => m.IntUserId == Id).ToList();
        }

        public override void BeforeNavigationFieldBind(UserDefinedRoleToUserMap t)
        {

        }
    }  

}