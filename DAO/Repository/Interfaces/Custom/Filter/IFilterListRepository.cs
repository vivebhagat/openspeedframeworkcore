using SpeedFramework.DAO.Model.Custom.Filter;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IFilterListRepository : IGenericActivableRepository<FilterList>
    {
        IEnumerable<object> LoadForFilterField(int id,int s, int n);
    }
}
