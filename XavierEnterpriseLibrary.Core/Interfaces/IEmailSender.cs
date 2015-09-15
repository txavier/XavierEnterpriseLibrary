using System;
namespace XavierEnterpriseLibrary.Core.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string from, System.Collections.Generic.IEnumerable<string> to, System.Collections.Generic.IEnumerable<string> cc, string subject, string emailMessage);
        bool? smtpDefaultCredentials { get; set; }
        bool? smtpEnableSSL { get; set; }
        string smtpHost { get; set; }
        string smtpNetworkPassword { get; set; }
        string smtpNetworkUserName { get; set; }
        int smtpPort { get; set; }
    }
}
