namespace Domain.Options;

public static class EmailOptions
{
    public const bool IsEmailSendingEnabled = false;

    public const string ReceiverEmailAddress = "";

    public const string SenderEmailAddress = "";

    public const string SenderPassword = "";

    public static class Smtp
    {
        public const string Host = "smtp.gmail.com";
    }
}
