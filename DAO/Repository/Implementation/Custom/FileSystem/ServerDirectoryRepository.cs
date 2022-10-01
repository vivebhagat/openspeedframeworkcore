using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using Common.Exceptions;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Custom.FileSystem;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class ServerDirectoryRepository : GenericRepository<ServerDirectory>, IServerDirectoryRepository
    {
        public override string entity_name
        {
            get { return "Server Folder"; }
            set { value = "Server Folder"; }
        }
        public override string entity_label
        {
            get { return "Server Folder"; }
            set { value = "Server Folder"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public ServerDirectoryRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext) : base(db,userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;

        }




        public override void BeforeNavigationFieldBind(ServerDirectory t)
        {
        }
        public override void Validate(ServerDirectory o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            CheckDuplicate(o , m=> m.Name==o.Name);
        }




        public override IQueryable<ServerDirectory> GetAccessFilterdSet()
        {
            return _set; //.Where(m=>m.OwnerId == userContext.CurrentUserId);
        }

        public string GetFullPath(ServerDirectory serverDirectory, List<ServerDirectory> directories)
        {
            ServerDirectory parentDirectory = serverDirectory.ParentDirectory;
            if (parentDirectory == null)
            {
                return serverDirectory.Name;
            }
            else {
                if (directories.Contains(parentDirectory))
                {
                    throw new DataProcessingException("Inconsistent diectory structure found.");
                }
                directories.Add(parentDirectory);
                return GetFullPath(parentDirectory, directories) + "/" + serverDirectory.Name;                
            }

        }

        public override void BeforeAdd(ServerDirectory o)
        {
            List<ServerDirectory> directory_list = new List<ServerDirectory>();
            o.FullPath = GetFullPath(o, directory_list);
        }

        public override void AfterAdd(ServerDirectory o)
        {
        }

        public override void BeforeEdit(ServerDirectory o)
        {
            List<ServerDirectory> directory_list = new List<ServerDirectory>();
            o.FullPath = GetFullPath(o, directory_list);
        }

        public override void AfterEdit(ServerDirectory o)
        {

        }

        public void Dispose()
        {
        }

    }
 }
