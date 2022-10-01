using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Services
{
    public class CommonApplicationUser : IdentityUser
    {
        public string dataroute { get; set; }
        public Guid domainkey { get; set; }
        [NotMapped]
        public string Password { get; internal set; }
        [NotMapped]
        public string ConfirmPassword { get; internal set; }
    }
}