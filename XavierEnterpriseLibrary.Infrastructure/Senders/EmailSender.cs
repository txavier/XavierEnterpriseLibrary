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
        public void SendEmail(string from, List<string> to, List<string> cc, string subject, string emailMessage)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress(from);

            if (to != null)
            {
                to.ForEach(i => message.To.Add(i));
            }
            else
            {
                throw new ArgumentNullException("Unable to send email, the receiving email addresses have not been specified.");
            }

            if (cc != null)
            {
                cc.ForEach(i => message.CC.Add(i));
            }

            message.Subject = subject;

            message.IsBodyHtml = true;

            message.Body = emailMessage;

            using (SmtpClient client = new SmtpClient())
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(message);
            }
        }

    }
}
