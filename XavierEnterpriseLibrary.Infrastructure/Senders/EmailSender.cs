using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using XavierEnterpriseLibrary.Core.Interfaces;

namespace XavierEnterpriseLibrary.Infrastructure.Senders
{
    public class EmailSender : IEmailSender
    {
        public string smtpHost { get; set; }

        public int smtpPort { get; set; }

        public bool? smtpEnableSSL { get; set; }

        public bool? smtpDefaultCredentials { get; set; }

        public string smtpNetworkUserName { get; set; }

        public string smtpNetworkPassword { get; set; }

        public void SendEmail(string from, IEnumerable<string> to, IEnumerable<string> cc, string subject, string emailMessage)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress(from);

            if (to != null)
            {
                to.ToList().ForEach(i => message.To.Add(i));
            }
            else
            {
                throw new ArgumentNullException("Unable to send email, the receiving email addresses have not been specified.");
            }

            if (cc != null)
            {
                cc.ToList().ForEach(i => message.CC.Add(i));
            }

            message.Subject = subject;

            message.IsBodyHtml = true;

            message.Body = emailMessage;

            using (SmtpClient client = new SmtpClient())
            {
                client.UseDefaultCredentials = smtpDefaultCredentials ?? false;

                client.Host = smtpHost;

                client.Credentials = new System.Net.NetworkCredential(smtpNetworkUserName, smtpNetworkPassword);

                client.Port = smtpPort;

                client.EnableSsl = smtpEnableSSL ?? false;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(message);
            }
        }

    }
}
