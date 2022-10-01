using SpeedFramework.DAO.Core.Model.UiSetup;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IOptionRepository : IGenericActivableRepository<Option>
    {
        IEnumerable<Option> GetForList(int Id);
    }
}
