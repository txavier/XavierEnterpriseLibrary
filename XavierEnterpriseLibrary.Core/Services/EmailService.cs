using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XavierEnterpriseLibrary.Core.Interfaces;

namespace XavierEnterpriseLibrary.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendEmail(string from, List<string> to, List<string> cc, string subject, string emailMessage, string siteUrl,
            string logoUrl, string secondarySubject = null, string logoPixelHeight = "24", string logoPixelWidth = "138")
        {
            var emailHtml = GetEmailHtml(subject, emailMessage, siteUrl, logoUrl: logoUrl, secondarySubject: secondarySubject, 
                logoPixelHeight: logoPixelHeight, logoPixelWidth: logoPixelWidth);

            _emailSender.SendEmail(from, to, cc, subject, emailHtml);
        }

        public string GetEmailHtml(string subject, string body, string siteUrl, string logoUrl = null, string secondarySubject = null,
            string logoPixelHeight = "24", string logoPixelWidth = "138")
        {
            var lines = body.Split(new string[] { "\n" }, StringSplitOptions.None);

            var aggregateLines = lines.Aggregate((current, next) =>
                "<tr><td class=\"first\" style=\"color:#444444;padding-right:5px;\"><strong>" + current + "</strong></td>"
                + "<td style=\"color:#444444;\"><strong></strong></td></tr>" +
                "<tr><td class=\"first\" style=\"color:#444444;padding-right:5px;\"><strong>" + next + "</strong></td>"
                + "<td style=\"color:#444444;\"><strong></strong></td></tr>");

            secondarySubject = string.IsNullOrEmpty(secondarySubject) || string.IsNullOrWhiteSpace(secondarySubject) ?
                string.Empty : secondarySubject;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\">");

            sb.AppendLine("<head>");

            sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");

            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"/>");

            sb.AppendLine("<title></title>");

            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine("            p{ margin: 1em 0;}");
            sb.AppendLine("            h2,h4{color:#444444;}");
            sb.AppendLine("            img {width:auto; max-width:138px}");
            sb.AppendLine("            table{border:none 0; border-collapse: collapse; width:600px;}");
            sb.AppendLine("            td{vertical-align: top;}");
            sb.AppendLine("            .main{ width:100%;}");
            sb.AppendLine("            .details{font-size: 16px;}");
            sb.AppendLine("            .details td.first{width:30%;}");
            sb.AppendLine("            .header sup {font-size:11px;vertical-align: 8px;}");
            sb.AppendLine("            .footer{font-size: 14px;}");
            sb.AppendLine("            .header h2 {font-size: 22px;}");
            sb.AppendLine("            @media screen and (max-width:600px) {");
            sb.AppendLine("                table[class=main] table{width:100%;}");
            sb.AppendLine("                table{width: 100%;}");
            sb.AppendLine("                .header h2 {font-size: 20px;}");
            sb.AppendLine("                .header sup {font-size: 10px; vertical-align: 7px;}");
            sb.AppendLine("            }");
            sb.AppendLine("            @media screen and (max-width:480px) {");
            sb.AppendLine("                .details{font-size: 14px;}");
            sb.AppendLine("                .details td.first{width:40%;}");
            sb.AppendLine("                .footer{font-size: 12px;}");
            sb.AppendLine("            }");
            sb.AppendLine("            @media screen and (max-width:360px) {");
            sb.AppendLine("                .header h2 {font-size: 16px;}");
            sb.AppendLine("                .header h4 {font-size: 12px;}");
            sb.AppendLine("                .details td.first{width:50%;}");
            sb.AppendLine("            }");
            sb.AppendLine("        </style>");
            sb.AppendLine("    </head>");
            sb.AppendLine("        <body style=\"margin:0;padding:0;font-family:Helvetica,sans-serif;color:#444444\">");
            sb.AppendLine("");
            sb.AppendLine("    <table class=\"main\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" bgcolor=\"#ffffff\">");
            sb.AppendLine("");
            sb.AppendLine("    <tr>");
            sb.AppendLine("");
            sb.AppendLine("    <td style=\"padding:20px 5px;\">");
            sb.AppendLine("");
            sb.AppendLine("    <table class=\"logo\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" width=\"600px\" style=\"display:block;\">");
            sb.AppendLine("");
            sb.AppendLine("    <tr>");
            sb.AppendLine("");
            sb.AppendLine("    <td>");
            sb.AppendLine("");
            sb.AppendLine("    <img src=\"" + logoUrl + "\" style=\"margin:auto; max-height: " + logoPixelHeight + "px;max-width: 138px;border-radius: 4px\" border=\"0\" alt=\"Logo\"/>");
            sb.AppendLine("");
            sb.AppendLine("    </td>");
            sb.AppendLine("");
            sb.AppendLine("    </tr>");
            sb.AppendLine("");
            sb.AppendLine("    </table>");
            sb.AppendLine("");
            sb.AppendLine("    </td>");
            sb.AppendLine("");
            sb.AppendLine("    </tr>");
            sb.AppendLine("");
            sb.AppendLine("    <tr>");
            sb.AppendLine("");
            sb.AppendLine("    <td style=\"padding:15px 5px;\" bgcolor=\"#e9f1f4\">");
            sb.AppendLine("");
            sb.AppendLine("    <table class=\"header\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" width=\"600px\">");
            sb.AppendLine("");
            sb.AppendLine("    <tr>");
            sb.AppendLine("");
            sb.AppendLine("    <td >");
            sb.AppendLine("");
            sb.AppendLine("    <h2 style=\"margin:0;letter-spacing:-1px;font-weight:bold;background:transparent;border:0; background-color:#e9f1f4; color:#444444;\">" + subject + "</h2>");
            sb.AppendLine("");
            sb.AppendLine("    <h4 style=\"margin:0;font-weight:lighter; color:#444444;\">" + secondarySubject + "</h3>");
            sb.AppendLine("");
            sb.AppendLine("    </td>");
            sb.AppendLine("");
            sb.AppendLine("    </tr>");
            sb.AppendLine("");
            sb.AppendLine("    </table>");
            sb.AppendLine("");
            sb.AppendLine("    </td>");
            sb.AppendLine("");
            sb.AppendLine("    </tr>");
            sb.AppendLine("");
            sb.AppendLine("    <tr>");
            sb.AppendLine("");
            sb.AppendLine("    <td style=\"padding:20px 5px;\">");
            sb.AppendLine("");
            sb.AppendLine("    <table class=\"details\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" width=\"600px\" style=\"display:block;\">");
            sb.AppendLine("");
            sb.AppendLine(aggregateLines);
            sb.AppendLine("");
            sb.AppendLine("    </table>");
            sb.AppendLine("");
            sb.AppendLine("    </td>");
            sb.AppendLine("");
            sb.AppendLine("    </tr>");
            sb.AppendLine("");
            sb.AppendLine("    <tr>");
            sb.AppendLine("");
            sb.AppendLine("    <td style=\"padding:0 5px;\">");
            sb.AppendLine("");
            sb.AppendLine("    <table class=\"footer\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" width=\"600px\">");
            sb.AppendLine("");
            sb.AppendLine("    <tr>");
            sb.AppendLine("");
            sb.AppendLine("    <td>");
            sb.AppendLine("");
            sb.AppendLine("    <p style=\"color:#444444;\">Go to <a href=\"" + siteUrl + "\">" + siteUrl + "</a>.</p>");
            sb.AppendLine("");
            sb.AppendLine("    <p style=\"color:#444444;\">Notification delivery may be delayed for various reasons, including service outages affecting your phone, wireless or internet provider; technology failures; and system capacity limitations. </p> ");
            sb.AppendLine("               ");
            sb.AppendLine("    </td>      ");
            sb.AppendLine("               ");
            sb.AppendLine("    </tr>      ");
            sb.AppendLine("               ");
            sb.AppendLine("    </table>   ");
            sb.AppendLine("               ");
            sb.AppendLine("    </td>      ");
            sb.AppendLine("               ");
            sb.AppendLine("    </tr>      ");
            sb.AppendLine("               ");
            sb.AppendLine("    </table>   ");
            sb.AppendLine("               ");
            sb.AppendLine("    </body>    ");
            sb.AppendLine("</html>        ");

            return sb.ToString();
        }
    }
}
