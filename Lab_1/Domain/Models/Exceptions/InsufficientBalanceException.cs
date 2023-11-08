namespace Domain.Models.Exceptions;

public class InsufficientBalanceException : ValidationException
{
    public InsufficientBalanceException()
    {
    }

    public InsufficientBalanceException(string message)
        : base(message)
    {
    }

    public InsufficientBalanceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
