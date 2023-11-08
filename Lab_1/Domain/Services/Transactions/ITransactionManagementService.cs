using Domain.Models.Entities;
using Domain.Models.Enums;
using Domain.Models.ValueObjects;

namespace Domain.Services.Transactions;

public interface ITransactionManagementService
{
    event EventHandler<string>? DepositTransactionCompletedEvent;
    event EventHandler<string>? DepositTransactionFailedEvent;

    event EventHandler<string>? WithdrawalTransactionCompletedEvent;
    event EventHandler<string>? WithdrawalTransactionFailedEvent;

    event EventHandler<string>? InternalTransactionCompletedEvent;
    event EventHandler<string>? InternalTransactionFailedEvent;

    void CreateDepositTransaction(CardNumber cardNumber, Guid atmId, decimal amount);

    void CreateWithdrawalTransaction(CardNumber cardNumber, Guid atmId, decimal amount);

    void CreateInternalTransaction(CardNumber cardNumberFrom, CardNumber cardNumberTo, decimal amount);

    List<Transaction> GetTransactionsForAccountWithTimeRange(CardNumber cardNumber,  TimeRangeOption timeRange);
}
