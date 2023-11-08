using Domain.Models.ValueObjects;
using Domain.Repositories;

namespace Domain.Services.Accounts;

public class AccountManagementService : IAccountManagementService
{
    private readonly IAccountRepository _accountRepository;

    public event EventHandler<string>? AuthenticationCompletedEvent;
    public event EventHandler<string>? AuthenticationFailedEvent;

    public event EventHandler<string>? BalanceRetrivalCompletedEvent;
    public event EventHandler<string>? BalanceRetrivalFailedEvent;

    public AccountManagementService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public bool AuthenticateAccount(CardNumber cardNumber, Pincode pincode)
    {
        var account = _accountRepository.GetByCardNumber(cardNumber);

        if (account is null)
        {
            AuthenticationFailedEvent?.Invoke(this, $"Account with card number {cardNumber} was not found");
            return false;
        }

        if (!account.Authenticate(pincode))
        {
            AuthenticationFailedEvent?.Invoke(this, "Pincode is incorrect");
            return false;
        }

        AuthenticationCompletedEvent?.Invoke(this, $"Welcome, {account.FirstName} {account.LastName}");

        return true;
    }

    public decimal? GetAccountBalance(CardNumber cardNumber)
    {
        var account = _accountRepository.GetByCardNumber(cardNumber);

        if (account is null)
        {
            BalanceRetrivalFailedEvent?.Invoke(this, $"Account with card number {cardNumber} was not found");
            return null;
        }

        var balance = account.CurrentBalance;

        BalanceRetrivalCompletedEvent?.Invoke(this, $"Current account balance: {balance}");

        return balance;
    }
}
