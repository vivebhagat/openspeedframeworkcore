using SpeedFramework.DAO.Model.Custom.Filter;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IFilterFieldRepository : IGenericActivableRepository<FilterField>
    {
        IEnumerable<FilterField> GetForFilter(int Id);
        IEnumerable<object> GetFieldOperatorList();
    }
}
