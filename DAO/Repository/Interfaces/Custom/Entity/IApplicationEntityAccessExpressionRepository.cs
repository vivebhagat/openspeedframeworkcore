using SpeedFramework.DAO.Model.Custom.Entity;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IApplicationEntityAccessExpressionRepository : IGenericActivableRepository<ApplicationEntityAccessExpression>
    {
         IEnumerable<ApplicationEntityAccessExpression> GetForEntity(int Id);
    }
}
