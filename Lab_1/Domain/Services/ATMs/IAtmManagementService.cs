using Domain.Models.Entities;
using Domain.Models.ValueObjects;

namespace Domain.Services.ATMs;

public interface IAtmManagementService
{
    event EventHandler<string>? BalanceRetrivalCompletedEvent;
    event EventHandler<string>? BalanceRetrivalFailedEvent;

    decimal? GetAtmBalance(Guid atmId);

    List<AutomatedTellerMachine> GetClosestAtmsByAddress(Address address);
}
