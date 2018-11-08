using System.Collections.Generic;
using Secretary.API.Helpers;

namespace Secretary.API.Interfaces
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}