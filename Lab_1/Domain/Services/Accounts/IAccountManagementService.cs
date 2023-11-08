using Domain.Models.ValueObjects;

namespace Domain.Services.Accounts;

public interface IAccountManagementService
{
    event EventHandler<string>? AuthenticationCompletedEvent;
    event EventHandler<string>? AuthenticationFailedEvent;

    event EventHandler<string>? BalanceRetrivalCompletedEvent;
    event EventHandler<string>? BalanceRetrivalFailedEvent;

    bool AuthenticateAccount(CardNumber cardNumber, Pincode pincode);

    decimal? GetAccountBalance(CardNumber cardNumber);
}
