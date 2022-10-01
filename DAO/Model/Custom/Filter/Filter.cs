using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Model.Custom.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedFramework.DAO.Model.Custom.Filter
{
    public class Filter : IActivableEntity
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public virtual ApplicationEntity ApplicationEntity { get; set; }
        public int? ApplicationEntityId { get; set; }
        public string Name { get; set; }
        public bool Inactive { get; set; }


        [NotMapped]
        public int PageSize { get; set; }
        [NotMapped]
        public int PageIndex { get; set; }

        [NotMapped]
        public string sortby { get; set; }
        [NotMapped]
        public bool IsDesc { get; set; }
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