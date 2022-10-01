using SpeedFramework.Common.CoreModels;
using System;

namespace SpeedFramework.DAO.Model.Access
{
    public class UserDefinedRoleToUserMap : IActivableEntity
    {
        public int Id { get; set; }
        public virtual UserDefinedRole Role { get; set; }
        public int? RoleId { get; set; }
        public virtual IntUser IntUser { get; set; }
        public int IntUserId { get; set; }
        public bool Inactive { get; set; }
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
