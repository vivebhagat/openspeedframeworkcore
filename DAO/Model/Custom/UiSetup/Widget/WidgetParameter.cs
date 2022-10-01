using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using System;

namespace SpeedFramework.DAO.Model.Custom.UiSetup.Widget
{
    public class WidgetParameter : IActivableEntity
    {
        public int Id { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }
        public virtual WidgetParameterType WidgetParameterType { get; set; }
        public int WidgetParameterTypeId { get; set; }
        public virtual WidgetData WidgetData { get; set; }
        public int WidgetDataId { get; set; }
        public string Expression { get; set; }
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