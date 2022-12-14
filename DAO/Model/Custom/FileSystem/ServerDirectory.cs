using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpeedFramework.DAO.Model.Custom.FileSystem
{
    public class ServerDirectory : TEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }
        public virtual ServerDirectory ParentDirectory { get; set; }
        public int? ParentDirectoryId { get; set; }
        public string FullPath { get; set; }

        //     public virtual IntUser Owner {get; set;}
        //     public int OwnerId { get; set; }

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