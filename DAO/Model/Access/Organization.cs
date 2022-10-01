using Common.Enum;
using SpeedFramework.Common.CoreModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedFramework.DAO.Model.Access
{
    public class Organization : Auditable, IActivableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int Postcode { get; set; }

        public int Phone { get; set; }

        public string Website { get; set; }

        public virtual CurrencyType Currency { get; set; }

        public string Description { get; set; }

        public string LogoImageUrl { get; set; }

        public int? ParentOrganizationId { get; set; }

        public bool IsParent { get; set; }

        public Organization ParentOrganization { get; set; }
        public bool Inactive { get; set; }
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }

        [InverseProperty("Org")]
        public List<IntUser> IntUsers { get; set; }

//        public int IntUsersId { get; set; }
    }
}