using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpeedFramework.Common.CoreModels;

namespace SpeedFramework.DAO.Model.Access
{


    public interface IBaseIntUser : TEntity
    {
        [Key]
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Name { get; set; }
        string UserId { get; set; }

        [EmailAddress]
        string Email { get; set; }

        DateTime DOB { get; set; }
        
        Organization Org { get; set; }

        int OrgId { get; set; }

        [NotMapped]
        string Password { get; set; }

        [NotMapped]
        string ConfirmPassword { get; set; }

    }

    public class IntUser : IBaseIntUser
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public virtual Organization Org { get; set; }

        public int OrgId { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }

     
    }

}