namespace Domain.Models.ValueObjects;

public record EmailMessage(string SenderEmailAddress, string ReceiverEmailAddress, string Title, string Body);