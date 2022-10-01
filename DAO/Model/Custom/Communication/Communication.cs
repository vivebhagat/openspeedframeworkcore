using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Model.Custom.Entity;
using System;

namespace SpeedFramework.DAO.Model.Custom.Communication
{
    public class Communication : TEntity
    {
        public int Id { get; set; }
        public virtual ApplicationEntity ApplicationEntity { get; set; }
        public int ApplicationEntityId { get; set; }

        public virtual CommunicationTemplate CommunicationTemplate { get; set; }
        public int CommunicationTemplateId { get; set; }

        public int eId { get; set; }
        public DateTime SentDate { get; set; }
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
