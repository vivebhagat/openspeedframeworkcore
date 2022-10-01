using SpeedFramework.DAO.Model.Custom.Communication;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface ICommunicationTemplateRoleRecieverMapRepository : IGenericActivableRepository<CommunicationTemplateRoleRecieverMap>
    {
        IEnumerable<CommunicationTemplateRoleRecieverMap> GetForTemplate(int Id);
    }
}
