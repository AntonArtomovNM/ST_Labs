using Domain.Models.ValueObjects;
using Domain.Options;
using Domain.Services.EmailSending;
using Domain.TestData;

namespace WinFormsApp;

public abstract class ExtendedFormWithEvents : ExtendedForm
{
    private readonly IEmailSendingService _emailSendingService;

    protected ExtendedFormWithEvents()
    {
        _emailSendingService = FakeContainer.EmailSendingService;
    }

    protected abstract void SubscribeToEvents();

    protected abstract void UnsubscribeFromEvents();

    protected void SendEmailNotification(string title, string body)
    {
        if (!EmailOptions.IsEmailSendingEnabled)
        {
            return;
        }

        var emailMessage = new EmailMessage($"[Lab1 - WinForms] {title}", body);

        _emailSendingService.SendEmail(emailMessage);
    }
}
