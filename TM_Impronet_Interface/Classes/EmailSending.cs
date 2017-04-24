using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface.Classes
{
    public static class EmailSending
    {
        public static void Send_Email(IEnumerable<string> to, string from, string subject, string html)
        {
            var mailMessage = new MailMessage { Subject = subject, Body = html, From = new MailAddress(from) };
            foreach (var address in to)
            {
                mailMessage.To.Add(address);
            }

            var mailSender = new SmtpClient(Settings.Default.SmtpHost,Settings.Default.SmtpPort)
            {
                EnableSsl = Settings.Default.SSL,
                Credentials = new NetworkCredential(Settings.Default.Username, Settings.Default.Password)
            };
            //specify your login/password to log on to the SMTP server, if required
            mailSender.Send(mailMessage);
        }
    }
}
