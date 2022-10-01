using SpeedFramework.DAO.Model.Custom.Communication;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface ICommunicationTemplateRepository : IGenericActivableRepository<CommunicationTemplate>
    {
        IEnumerable<CommunicationTemplate> GetForEntity(int id);
    }
}
