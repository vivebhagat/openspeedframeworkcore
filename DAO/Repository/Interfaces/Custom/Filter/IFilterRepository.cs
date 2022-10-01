using System.Collections.Generic;
using Common.Filter;
using SpeedFramework.DAO.Model.Custom.Filter;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IFilterRepository : IGenericActivableRepository<Filter>
    {
        IEnumerable<Filter> GetForEntity(int Id);
        FilterResult<dynamic> Filter(int id,int s, int n);
        FilterResult<dynamic> _postFilter(int Id, IEnumerable<FilterField> filterFields, int s, int n);
    }
}
