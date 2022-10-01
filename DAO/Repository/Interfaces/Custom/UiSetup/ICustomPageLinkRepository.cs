﻿using SpeedFramework.DAO.Core.Model.UiSetup;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface ICustomPageLinkRepository : IGenericActivableRepository<CustomPageLink>
    {
        IEnumerable<CustomPageLink> GetForPage(int Id);
    }
}
