using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using System;
using System.ComponentModel.DataAnnotations;


namespace SpeedFramework.DAO.Model.Custom.FileSystem
{
    public class GroupToApplicationFileMapping : IActivableEntity
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationNumber { get; set; }
        public bool Inactive { get; set; }
        public string LegacyNumber { get; set; }
        public virtual ApplicationFileType ApplicationFileType { get; set; }
        public int ApplicationFileTypeId { get; set; }
        public virtual ApplicationFileGroup ApplicationFileGroup { get; set; }
        public int ApplicationFileGroupId { get; set; }
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