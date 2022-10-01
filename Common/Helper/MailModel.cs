using System.ComponentModel.DataAnnotations;

namespace Common.Helper
{

    public class MailModel
    {        
        public string From { get; set; }
        public string To { get; set; }
        
        public string Body { get; set; }

        [Required(ErrorMessage = "Subject is mandetory.")]
        public string Subject { get; set; }

    }
}