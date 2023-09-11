using System.Text.RegularExpressions;
using Domain.Models.Exceptions;

namespace Domain.Models.ValueObjects;
public record struct CardNumber
{
    private const string CardNumberRegex = @"^[0-9]{13,19}$";

    public string Value { get; }

    public CardNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException("Card number cannot be empty");
        }

        if (!Regex.IsMatch(value, CardNumberRegex))
        {
            throw new ValidationException("Card number should consist of 13-19 digits");
        }

        Value = value;
    }

    public override string ToString() => Value;
}
