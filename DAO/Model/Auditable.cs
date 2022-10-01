using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using System;

namespace SpeedFramework.Common.CoreModels
{
    public abstract class Auditable : IAuditable
    {

        public virtual IntUser CreatedBy { get; set; }
        public int? CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual IntUser ModifiedBy { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual IntUser ArchieveBy { get; set; }
        public int? ArchieveById { get; set; }
        public DateTime? ArchieveDate { get; set; }


        public static void MarkCreatedDate(IAuditable auditable, IntUser user)
        {
            auditable.CreatedDate = DateTime.Now;
            auditable.CreatedBy = user;
            auditable.CreatedById = user.Id;

        }


        public static void MarkDeletedDate(IAuditable auditable,IntUser user)
        {
            auditable.ArchieveDate = DateTime.Now;
            auditable.ArchieveBy = user;
            auditable.ArchieveById = user.Id;

        }

        public static void MarkModifiedDate(IAuditable auditable, IModelContext db, IntUser user)
        {
            db.GetDbContext().Entry(auditable).Property(m => m.CreatedDate).IsModified = false;
            db.GetDbContext().Entry(auditable).Property(m => m.CreatedById).IsModified = false;
            auditable.ModifiedDate = DateTime.Now;
            auditable.ModifiedBy = user;
            auditable.ModifiedById = user.Id;
        }



        public void CopyStamp(IAuditable auditable)
        {
            auditable.ArchieveDate = this.ArchieveDate;
            auditable.CreatedDate = this.CreatedDate;
            auditable.ModifiedDate = this.ModifiedDate;
        }
    }
}