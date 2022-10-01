using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Custom.FileSystem;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class GroupToApplicationFileMappingRepository : GenericActivableRepository<GroupToApplicationFileMapping>, IGroupToApplicationFileMappingRepository
    {
        public override string entity_name
        {
            get { return "Group To File Mapping"; }
            set { value = "Group To File Mapping"; }
        }
        public override string entity_label
        {
            get { return "Group To File Mapping"; }
            set { value = "Group To File Mapping"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public GroupToApplicationFileMappingRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db,userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }



        public override void BeforeNavigationFieldBind(GroupToApplicationFileMapping t)
        {
        }

        public override void Validate(GroupToApplicationFileMapping o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }




        public override IQueryable<GroupToApplicationFileMapping> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(GroupToApplicationFileMapping o)
        {
        }

        public override void AfterAdd(GroupToApplicationFileMapping o)
        {

        }

        public override void BeforeEdit(GroupToApplicationFileMapping o)
        {
        }

        public override void AfterEdit(GroupToApplicationFileMapping o)
        {

        }

        public void Dispose()
        {
        }

    }
 }
