using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedFramework.DAO.Model.Custom.Entity
{

    [Table("ApplicationEntities")]
    public class ApplicationEntity : IActivableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Inactive { get; set; }
        public bool IsStandard { get; set; }
        public bool IsOwnershipEntity { get; set; }
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string NumberFormat { get; set; }
        public bool IsGlobalSearchble { get; set; }
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
