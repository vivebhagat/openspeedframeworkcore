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
    public class ApplicationFileTypeRepository : GenericRepository<ApplicationFileType>, IApplicationFileTypeRepository
    {
        public override string entity_name
        {
            get { return "Application File Type"; }
            set { value = "Application File Type"; }
        }
        public override string entity_label
        {
            get { return "Application File Type"; }
            set { value = "Application File Type"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public ApplicationFileTypeRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext) : base(db,userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }



        public override void BeforeNavigationFieldBind(ApplicationFileType t)
        {
        }

        public override void Validate(ApplicationFileType o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }




        public override IQueryable<ApplicationFileType> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(ApplicationFileType o)
        {
        }

        public override void AfterAdd(ApplicationFileType o)
        {

        }

        public override void BeforeEdit(ApplicationFileType o)
        {
        }

        public override void AfterEdit(ApplicationFileType o)
        {

        }

        public void Dispose()
        {
        }

    }
 }
