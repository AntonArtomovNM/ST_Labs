﻿using System.Net;
using System.Net.Mail;
using Domain.Models.ValueObjects;
using Domain.Options;

namespace Domain.Services.EmailSending;

public class SmtpEmailSendingService : IEmailSendingService
{
    private readonly SmtpClient _smtpClient;

    public SmtpEmailSendingService()
    {
        _smtpClient = new SmtpClient(EmailOptions.Smtp.Host)
        {
            Port = 587,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(EmailOptions.SenderEmailAddress, EmailOptions.SenderPassword),
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network
        };
    }

    public void SendEmail(EmailMessage email)
    {
        var mailMessage = new MailMessage(EmailOptions.SenderEmailAddress, EmailOptions.ReceiverEmailAddress, email.Title, email.Body);

        _smtpClient.Send(mailMessage);
    }
}
