using System.ComponentModel.DataAnnotations;

namespace SpeedFramework.DAO.Commmon
{
    public class SystemSetup
    {

        [Display(Name = "SMTP Host URL")]
        public  string SMTP_HOST_URL { get; set; }

        [Display(Name = "SMTP Port")]
        public  int SMTP_PORT { get; set; }

        [Display(Name = "Google Map API Key")]
        public  string GOOGLE_MAP_API_KEY { get; set; }

        [Display(Name = "SMTP Username")]
        public string SMTP_USERNAME { get; set; }

        [Display(Name = "SMTP Password")]
        public string SMTP_PASSWORD { get; set; }
    }
}