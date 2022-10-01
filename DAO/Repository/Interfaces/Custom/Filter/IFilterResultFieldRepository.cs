using SpeedFramework.DAO.Model.Custom.Filter;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IFilterResultFieldRepository : IGenericActivableRepository<FilterResultField>
    {
        IEnumerable<FilterResultField> GetForFilter(int Id);
    }
}
