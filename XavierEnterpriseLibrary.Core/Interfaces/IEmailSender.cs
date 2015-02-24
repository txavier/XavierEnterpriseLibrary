using System;
namespace XavierEnterpriseLibrary.Core.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string from, System.Collections.Generic.List<string> to, System.Collections.Generic.List<string> cc, string subject, string emailMessage);
    }
}
