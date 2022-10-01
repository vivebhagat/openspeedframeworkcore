using SpeedFramework.DAO.Model.Custom.FileSystem;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IServerDirectoryRepository : IGenericRepository<ServerDirectory>
    {
        string GetFullPath(ServerDirectory serverDirectory, List<ServerDirectory> directories);
    }
}
