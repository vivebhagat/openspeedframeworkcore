using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Model.Custom.Entity;
using System;

namespace SpeedFramework.DAO.Core.Model.UiSetup
{

    public class Field : IActivableEntity
    {
        public int Id { get; set; }

        public virtual FieldType FieldType { get; set; }
        public int FieldTypeId { get; set; }
        
        public virtual ApplicationEntityProperty ApplicationEntityProperty { get; set; }
        public int? ApplicationEntityPropertyId { get; set; }
        public bool Inactive { get; set; }
        public bool IsStandard { get; set; }
        public bool IsMultiSelect {get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public string Label { get; set; }
        public bool IsMandatory { get; set; }
        public bool IncludeInName { get; set; }
        public string  NameTransform { get; set; }
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
