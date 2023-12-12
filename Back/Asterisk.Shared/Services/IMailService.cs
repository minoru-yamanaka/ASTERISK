using Asterisk.Shared.Models;

namespace Asterisk.Shared.Services
{
    public interface IMailService
    {
        // to send an email manually 
        Task SendEmailAsync(MailRequest mailRequest);

        // to send an email automatically with template
        Task SendAlertEmail(string emailUser, int amountOfPeople);
    }
}
