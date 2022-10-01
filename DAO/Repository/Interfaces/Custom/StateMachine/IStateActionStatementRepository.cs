using SpeedFramework.DAO.Model.Custom.StateMachine;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IStateActionStatementRepository : IGenericActivableRepository<StateActionStatement>
    {
        IEnumerable<StateActionStatement> GetForStateAction(int id);
    }


}
