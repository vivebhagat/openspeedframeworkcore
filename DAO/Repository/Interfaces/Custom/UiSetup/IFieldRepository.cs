using SpeedFramework.DAO.Core.Model.UiSetup;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IFieldRepository : IGenericActivableRepository<Field>
    {
        IEnumerable<Option> GetOptions(int Id);
        IEnumerable<Field> GetForEntity(int Id);
    }


}
