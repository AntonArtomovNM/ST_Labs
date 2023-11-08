using Domain.Models.ValueObjects;

namespace Domain.Services.EmailSending;

public interface IEmailSendingService
{
    void SendEmail(EmailMessage email);
}
