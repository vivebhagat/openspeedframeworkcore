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
    public class ApplicationFileGroupRepository : GenericRepository<ApplicationFileGroup>, IApplicationFileGroupRepository
    {
        public override string entity_name
        {
            get { return "Application File Group"; }
            set { value = "Application File Group"; }
        }
        public override string entity_label
        {
            get { return "Application File Group"; }
            set { value = "Application File Group"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public ApplicationFileGroupRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext) : base(db,userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }





        public override void Validate(ApplicationFileGroup o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }


        public override void BeforeNavigationFieldBind(ApplicationFileGroup t)
        {
        }

        public override IQueryable<ApplicationFileGroup> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(ApplicationFileGroup o)
        {
        }

        public override void AfterAdd(ApplicationFileGroup o)
        {

        }

        public override void BeforeEdit(ApplicationFileGroup o)
        {
        }

        public override void AfterEdit(ApplicationFileGroup o)
        {

        }

        public void Dispose()
        {
        }

    }
 }
