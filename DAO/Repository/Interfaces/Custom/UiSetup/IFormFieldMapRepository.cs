using SpeedFramework.DAO.Core.Model.UiSetup;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IFormFieldMapRepository : IGenericActivableRepository<FormFieldMap>
    {
        IEnumerable<FormFieldMap> GetAllForForm(int id);
    }
}
