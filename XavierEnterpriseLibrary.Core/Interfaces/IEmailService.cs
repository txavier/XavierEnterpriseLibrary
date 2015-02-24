using System;
namespace XavierEnterpriseLibrary.Core.Interfaces
{
    public interface IEmailService
    {
        string GetEmailHtml(string subject, string body, string siteUrl, string logoUrl = null, string secondarySubject = null);
        void SendEmail(string from, System.Collections.Generic.List<string> to, System.Collections.Generic.List<string> cc, string subject, string emailMessage, string siteUrl, string logoUrl, string secondarySubject = null);
    }
}
