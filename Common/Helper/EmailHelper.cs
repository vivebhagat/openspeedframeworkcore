using Common.Standard;
using System;
using System.Net.Mail;
using System.Net.Mime;

namespace Common.Helper
{
    public class EmailHelper
    {

        public static void Email(string From, string To, string emailSubject, string emailText, string Username, string Password, string smtpurl, int port)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtpurl);
            mail.From = new MailAddress(From);
            string _to = To;
   
            mail.To.Add(_to);
            mail.Subject = emailSubject;
            mail.Body = emailText;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            SmtpServer.Port = port;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Username, Password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        public static void SendEmail(MailModel mailModel)
        {
            MailAddress from_address = new MailAddress(mailModel.From);
            MailAddress to_address = new MailAddress(mailModel.To);


            MailMessage mail = new MailMessage(from_address, to_address);
            mail.IsBodyHtml = true;

            String comm = mailModel.Body ?? String.Empty;

            if (comm != null)
            {
                string comm_after = comm != null ? comm : String.Empty; //comm != null ? comm.Replace("\n", "<br>") : String.Empty;
                AlternateView av1 = AlternateView.CreateAlternateViewFromString(
                      "<div>" + comm_after + "<br><br></div><div><br></div>"
                      , null, MediaTypeNames.Text.Html);
                mail.AlternateViews.Add(av1);
            }


            mail.IsBodyHtml = true;
            mail.Subject = mailModel.Subject;
            SmtpClient smtp = new SmtpClient(GlobalVariables.SMTP_HOST_URL.ToString());
            smtp.EnableSsl = true;
            smtp.Port = GlobalVariables.SMTP_PORT;
            smtp.Credentials = new System.Net.NetworkCredential(GlobalVariables.SMTP_USERNAME, GlobalVariables.SMTP_PASSWORD);
            //            smtp.UseDefaultCredentials = true;
            smtp.Send(mail);
        }
    }
}