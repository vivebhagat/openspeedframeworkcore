using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using System;

namespace SpeedFramework.DAO.Core.Model.UiSetup
{
    public class FormFieldMap : IActivableEntity
    {   
        public int Id { get; set; }
        public virtual Form Form { get; set; }
        public virtual Field Field { get; set; }

        public int FormId { get; set; }
        public int FieldId { get; set; }
        public bool Inactive { get; set;}
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }
        public virtual IntUser CreatedBy { get; set; }
        public int? CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual IntUser ModifiedBy { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual IntUser ArchieveBy { get; set; }
        public int? ArchieveById { get; set; }
        public DateTime? ArchieveDate { get; set; }
    }
}
