using SpeedFramework.DAO.Model.Custom.Communication;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface ICommunicationTemplateUserRecieverMapRepository : IGenericActivableRepository<CommunicationTemplateUserRecieverMap>
    {
        IEnumerable<CommunicationTemplateUserRecieverMap> GetForTemplate(int Id);
    }
}
