using System.Security.Principal;
using Domain.Models.Entities;
using Domain.Models.Enums;
using Domain.Models.Exceptions;
using Domain.Models.ValueObjects;
using Domain.Repositories;

namespace Domain.Services.Transactions;

public class TransactionManagementService : ITransactionManagementService
{
    private readonly ITransactionRepository _transactionRepository;

    private readonly IAccountRepository _accountRepository;
    
    private readonly IAtmRepository _atmRepository;

    public event EventHandler<string>? DepositTransactionCompletedEvent;
    public event EventHandler<string>? DepositTransactionFailedEvent;

    public event EventHandler<string>? WithdrawalTransactionCompletedEvent;
    public event EventHandler<string>? WithdrawalTransactionFailedEvent;

    public event EventHandler<string>? InternalTransactionCompletedEvent;
    public event EventHandler<string>? InternalTransactionFailedEvent;

    public TransactionManagementService(
    ITransactionRepository transactionRepository,
    IAccountRepository accountRepository,
    IAtmRepository atmRepository)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
        _atmRepository = atmRepository;
    }

    public void CreateDepositTransaction(CardNumber cardNumber, Guid atmId, decimal amount)
    {
        var account = _accountRepository.GetByCardNumber(cardNumber);

        if (account is null)
        {
            DepositTransactionFailedEvent?.Invoke(this, $"Account with card number {cardNumber} was not found");
            return;
        }

        var atm = _atmRepository.GetById(atmId);

        if (atm is null)
        {
            DepositTransactionFailedEvent?.Invoke(this, $"ATM with id {atmId} was not found");
            return;
        }

        Transaction transaction;

        try
        {
            transaction = Transaction.CreateDeposit(account, atm, amount);

            _transactionRepository.Create(transaction);

        }
        catch (ValidationException ex)
        {
            DepositTransactionFailedEvent?.Invoke(this, ex.Message);
            return;
        }

        ExecuteTransaction(transaction, DepositTransactionCompletedEvent, DepositTransactionFailedEvent);
    }

    public void CreateWithdrawalTransaction(CardNumber cardNumber, Guid atmId, decimal amount)
    {
        var account = _accountRepository.GetByCardNumber(cardNumber);

        if (account is null)
        {
            WithdrawalTransactionFailedEvent?.Invoke(this, $"Account with card number {cardNumber} was not found");
            return;
        }

        var atm = _atmRepository.GetById(atmId);

        if (atm is null)
        {
            WithdrawalTransactionFailedEvent?.Invoke(this, $"ATM with id {atmId} was not found");
            return;
        }

        Transaction transaction;

        try
        {
            transaction = Transaction.CreateWithdrawal(account, atm, amount);

            _transactionRepository.Create(transaction);

        }
        catch (ValidationException ex)
        {
            WithdrawalTransactionFailedEvent?.Invoke(this, ex.Message);
            return;
        }

        ExecuteTransaction(transaction, WithdrawalTransactionCompletedEvent, WithdrawalTransactionFailedEvent);
    }

    public void CreateInternalTransaction(CardNumber cardNumberFrom, CardNumber cardNumberTo, decimal amount)
    {
        var accountFrom = _accountRepository.GetByCardNumber(cardNumberFrom);

        if (accountFrom is null)
        {
            InternalTransactionFailedEvent?.Invoke(this, $"Account with card number {cardNumberFrom} was not found");
            return;
        }
        
        var accountTo = _accountRepository.GetByCardNumber(cardNumberTo);

        if (accountTo is null)
        {
            InternalTransactionFailedEvent?.Invoke(this, $"Account with card number {cardNumberTo} was not found");
            return;
        }

        Transaction transaction;

        try
        {
            transaction = Transaction.CreateInternal(accountFrom, accountTo, amount);

            _transactionRepository.Create(transaction);

        }
        catch (ValidationException ex)
        {
            InternalTransactionFailedEvent?.Invoke(this, ex.Message);
            return;
        }

        ExecuteTransaction(transaction, InternalTransactionCompletedEvent, InternalTransactionFailedEvent);
    }

    public List<Transaction> GetTransactionsForAccountWithTimeRange(CardNumber cardNumber, TimeRangeOption timeRange)
    {
        var account = _accountRepository.GetByCardNumber(cardNumber);

        if (account is null)
        {
            return new List<Transaction>();
        }

        return _transactionRepository.GetByAccountIdWithinTimeRange(account.Id, timeRange);
    }

    private void ExecuteTransaction(Transaction transaction, EventHandler<string>? onSuccess, EventHandler<string>? onFail)
    {
        bool isExecutedSuccessfully = transaction.Execute();

        if (isExecutedSuccessfully)
        {
            onSuccess?.Invoke(this, "Transaction executed successfully");
        }
        else
        {
            onFail?.Invoke(this, $"Transaction execution failed with error message: {transaction.FailReason}");
        }
    }
}
