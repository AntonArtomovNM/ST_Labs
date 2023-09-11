using System.Text.RegularExpressions;
using Domain.Models.Exceptions;

namespace Domain.Models.ValueObjects;

public record struct Pincode
{
    private const string PincodeRegex = @"^[0-9]{4}$";

    public string Value { get; }

    public Pincode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException("Pincode cannot be empty");
        }

        if (!Regex.IsMatch(value, PincodeRegex))
        {
            throw new ValidationException("Pincode should consist of 4 digits");
        }

        Value = value;
    }

    public override string ToString() => Value;
}
