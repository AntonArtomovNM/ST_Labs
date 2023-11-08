using Domain.Models.ValueObjects;

namespace Domain.Models.Entities;

public class Bank : Entity
{
    private readonly List<Account> _accounts = new List<Account>();
    private readonly List<AutomatedTellerMachine> _atms = new List<AutomatedTellerMachine>();

    public string Name { get; private set; }

    public IReadOnlyCollection<Account> Accounts => _accounts;

    public IReadOnlyCollection<AutomatedTellerMachine> ATMs => _atms;

    public Bank(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
    }

    public Account OpenAccount(
        CardNumber cardNumber,
        Pincode pincode,
        string firstName,
        string lastName)
    {
        var account = new Account(Id, cardNumber, pincode, firstName, lastName);

        _accounts.Add(account);

        return account;
    }

    public AutomatedTellerMachine OpenAtm(Coordinates coordinates)
    {
        var atm = new AutomatedTellerMachine(Id, coordinates);

        _atms.Add(atm);

        return atm;
    }
}
