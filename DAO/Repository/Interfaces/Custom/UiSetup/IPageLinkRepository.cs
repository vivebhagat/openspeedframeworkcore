using SpeedFramework.DAO.Core.Model.UiSetup;
using System;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IPageLinkRepository : IGenericActivableRepository<PageLink>
    {
        bool LoadUILinks(IList<Tuple<string, string>> result);
    }
}