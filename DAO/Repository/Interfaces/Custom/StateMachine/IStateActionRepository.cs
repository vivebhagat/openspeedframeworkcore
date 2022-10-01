using SpeedFramework.DAO.Model.Custom.StateMachine;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IStateActionRepository : IGenericActivableRepository<StateAction>
    {
        IEnumerable<StateAction> GetForEntity(int Id);
    }


}
