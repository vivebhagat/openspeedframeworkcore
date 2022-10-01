using SpeedFramework.DAO.Model.Access;
using System;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IPageAccessRepository : IGenericActivableRepository<PageAccess>
    {
        bool AddToAccess(int pagelinkid, int roleid);
        IEnumerable<Tuple<string, string>> GetLinksForPage(string PageName);
        IEnumerable<PageAccess> GetPageAccessForRole(int Id);
        IEnumerable<PageAccess> GetPageAccess();
        bool RemoveFromAccess(int roleid, int pagelinkid);
        bool CheckLink(string url);
    }
}