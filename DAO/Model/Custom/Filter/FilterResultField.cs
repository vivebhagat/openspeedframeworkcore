using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using System;

namespace SpeedFramework.DAO.Model.Custom.Filter
{
    public class FilterResultField : IActivableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Expression { get; set; }
        public virtual Filter CommonFilter { get; set; }
        public int CommonFilterId { get; set; }
        public bool Inactive { get; set; }
        public bool ExcludeInQueryExpression { get; set; }
        public string ViewTransformExpression { get; set; }
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