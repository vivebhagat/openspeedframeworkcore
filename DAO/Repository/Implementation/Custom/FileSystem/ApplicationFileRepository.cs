using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Custom.FileSystem;
using System;
using Common.Exceptions;
using System.IO;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class ApplicationFileRepository : GenericRepository<ApplicationFile>, IApplicationFileRepository
    {
        public override string entity_name
        {
            get { return "Application File"; }
            set { value = "Application File"; }
        }
        public override string entity_label
        {
            get { return "Application File"; }
            set { value = "Application File"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public ApplicationFileRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext) : base(db,userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }


        public override void BeforeNavigationFieldBind(ApplicationFile t)
        {
            t.OwnerId = userContext.CurrentUserId;
        }


        public override void Validate(ApplicationFile o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            string file_directory = accountContext.ServerDirectoryRoot; 
            if (String.IsNullOrEmpty(file_directory))
                throw new DataProcessingException("Server Storage is not configured.");
        }




        public override IQueryable<ApplicationFile> GetAccessFilterdSet()
        {
            return _set.Where(m => m.OwnerId == userContext.CurrentUserId);
        }

        public override void BeforeAdd(ApplicationFile o)
        {
            string file_dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, accountContext.ServerDirectoryRoot, o.ServerDirectory.FullPath);
            if (String.IsNullOrEmpty(file_dir))
                throw new DataProcessingException("Directory does not exist.");
        }

        public override void AfterAdd(ApplicationFile o)
        {
           

        }

        public override void BeforeEdit(ApplicationFile o)
        {
        }

        public override void AfterEdit(ApplicationFile o)
        {

        }

        public void Dispose()
        {
        }

    }
 }
