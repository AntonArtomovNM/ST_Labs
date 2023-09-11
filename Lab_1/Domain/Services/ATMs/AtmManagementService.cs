using Domain.Models.Entities;
using Domain.Models.ValueObjects;
using Domain.Repositories;

namespace Domain.Services.ATMs;

public class AtmManagementService : IAtmManagementService
{
    private readonly IAtmRepository _atmRepository;

    public event EventHandler<string>? BalanceRetrivalCompletedEvent;
    public event EventHandler<string>? BalanceRetrivalFailedEvent;

    public AtmManagementService(IAtmRepository atmRepository)
    {
        _atmRepository = atmRepository;
    }

    public decimal? GetAtmBalance(Guid atmId)
    {
        var account = _atmRepository.GetById(atmId);

        if (account is null)
        {
            BalanceRetrivalFailedEvent?.Invoke(this, $"ATM with id {atmId} was not found");
            return null;
        }

        var balance = account.CurrentBalance;

        BalanceRetrivalCompletedEvent?.Invoke(this, $"Current ATM balance: {balance}");

        return balance;
    }

    public List<AutomatedTellerMachine> GetClosestAtmsByAddress(Address address)
    {
        return _atmRepository.GetClosestByAddress(address);
    }
}
