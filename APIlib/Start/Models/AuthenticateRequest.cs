using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public int UserDefinedRole { get; set; }
        public string CurrentToken { get; set; }
        public string DataRoute { get; set; }
    }
}