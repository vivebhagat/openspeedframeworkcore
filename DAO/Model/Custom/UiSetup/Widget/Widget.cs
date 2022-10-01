using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Access;
using System;

namespace SpeedFramework.DAO.Model.Custom.UiSetup.Widget
{
    public class Widget : IActivableEntity
    {
        public int Id { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }
        public virtual WidgetType WidgetType { get; set; }
        public int WidgetTypeId { get; set; }
        public virtual WidgetTemplate WidgetTemplate { get; set; }
        public int WidgetTemplateId { get; set; }
        public virtual Dashboard Dashboard { get; set; }
        public int DashboardId { get; set; }
        public virtual WidgetData WidgetData { get; set; }
        public int? WidgetDataId { get; set; }
        public int Index { get; set; }
        public int Row { get; set; }
        public int ColSpan { get; set; }
        public int RowSpan { get; set; }
        public string Style {get; set;}
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