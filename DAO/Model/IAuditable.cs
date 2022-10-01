using SpeedFramework.DAO.Model.Access;
using System;

namespace SpeedFramework.Common.CoreModels
{
    public interface IAuditable
    {
        IntUser CreatedBy { get; set; }
        int? CreatedById { get; set; }
        DateTime CreatedDate { get; set; }

        IntUser ModifiedBy { get; set; }
        int? ModifiedById { get; set; }
        DateTime? ModifiedDate { get; set; }

        IntUser ArchieveBy { get; set; }
        int? ArchieveById { get; set; }
        DateTime? ArchieveDate { get; set; }
    }
}