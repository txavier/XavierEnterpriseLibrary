using System;
namespace XavierEnterpriseLibrary.Core.Interfaces
{
    public interface IEmailService
    {
        string GetEmailHtml(string subject, string body, string siteUrl, string logoUrl = null, string secondarySubject = null, string logoPixelHeight = "24", string logoPixelWidth = "138");
        void SendEmail(string from, System.Collections.Generic.IEnumerable<string> to, System.Collections.Generic.IEnumerable<string> cc, string subject, string emailMessage, string siteUrl, string logoUrl, string secondarySubject = null, string logoPixelHeight = "24", string logoPixelWidth = "138");
        bool? smtpDefaultCredentials { get; set; }
        bool? smtpEnableSSL { get; set; }
        string smtpHost { get; set; }
        string smtpNetworkPassword { get; set; }
        string smtpNetworkUserName { get; set; }
        int smtpPort { get; set; }
    }
}
