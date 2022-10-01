using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Model.Custom.Entity;
using System;

namespace SpeedFramework.DAO.Model.Custom.Communication
{
    public class CommunicationTemplate : IActivableEntity
    {
        public int Id { get; set; }
        public virtual ApplicationEntity ApplicationEntity { get; set; }
        public int? ApplicationEntityId { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }
        public virtual CommunicationType CommunicationType { get; set; }
        public int CommunicationTypeId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public virtual IntUser From { get; set; }
        public int FromId { get; set; }
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }
        public virtual IntUser CreatedBy { get; set; }
        public int? CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual  IntUser ModifiedBy { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual IntUser ArchieveBy { get; set; }
        public int? ArchieveById { get; set; }
        public DateTime? ArchieveDate { get; set; }
    }

}
