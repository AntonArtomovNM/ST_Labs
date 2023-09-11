using Domain.Models.Enums;
using Domain.Models.Exceptions;

namespace Domain.Models.Entities;

public class Transaction : Entity
{
    public event EventHandler<string>? TransactionCompletedEvent;
    public event EventHandler<string>? TransactionFailedEvent;

    public Account? AccountFrom { get; }

    public Account? AccountTo { get; }

    public AutomatedTellerMachine? AtmFrom { get; }

    public AutomatedTellerMachine? AtmTo { get; }

    public decimal Amount { get; }

    public TransactionType Type { get; }

    public string Purpose { get; }

    public TransactionStatus Status { get; private set; }

    public string? FailReason { get; private set; }

    public DateTime? ExecutedAtUtc { get; set; }

    private Transaction(
        Account? accountFrom,
        Account? accountTo,
        AutomatedTellerMachine? atmFrom,
        AutomatedTellerMachine? atmTo,
        decimal amount,
        TransactionType type,
        string purpose)
    {
        if (amount <= 0)
        {
            throw new ValidationException("Transaction amount must be positive");
        }

        if (string.IsNullOrWhiteSpace(purpose))
        {
            throw new ValidationException("Transaction purpose is required");
        }

        AccountFrom = accountFrom;
        AccountTo = accountTo;
        AtmFrom = atmFrom;
        AtmTo = atmTo;
        Amount = amount;
        Type = type;
        Purpose = purpose;

        Status = TransactionStatus.New;
    }

    public static Transaction CreateDeposit(Account account, AutomatedTellerMachine atm, decimal amount)
    {
        if (account is null)
        {
            throw new ValidationException("Destination account is required for deposit transaction");
        }

        if (atm is null)
        {
            throw new ValidationException("Destination ATM is required for deposit transaction");
        }

        return new(
            accountFrom: null,
            accountTo: account,
            atmFrom: null,
            atmTo: atm,
            amount,
            TransactionType.Deposit,
            $"Deposit on {account.CardNumber}");
    }

    public static Transaction CreateWithdrawal(Account account, AutomatedTellerMachine atm, decimal amount)
    {
        if (account is null)
        {
            throw new ValidationException("Source account is required for withdrawal transaction");
        }

        if (atm is null)
        {
            throw new ValidationException("Source ATM is required for withdrawal transaction");
        }

        return new(
            accountFrom: account,
            accountTo: null,
            atmFrom: atm,
            atmTo: null,
            amount,
            TransactionType.Withdrawal,
            $"Withdrawal from {account.CardNumber}");
    }

    public static Transaction CreateInternal(Account accountFrom, Account accountTo, decimal amount)
    {
        if (accountFrom is null)
        {
            throw new ValidationException("Source account is required for internal transaction");
        }

        if (accountTo is null)
        {
            throw new ValidationException("Destination account is required for internal transaction");
        }

        if (accountFrom.CardNumber == accountTo.CardNumber)
        {
            throw new ValidationException("Source account cannot be used as destination for the internal transaction");
        }

        return new(
            accountFrom: accountFrom,
            accountTo: accountTo,
            atmFrom: null,
            atmTo: null,
            amount,
            TransactionType.Internal,
            $"Internal transfer from {accountFrom.CardNumber} to {accountTo.CardNumber}");
    }

    public void Execute()
    {
        if (ExecutedAtUtc.HasValue)
        {
            throw new InvalidOperationException("Transaction has been already executed");
        }

        try
        {
            AccountFrom?.Withdraw(Amount);
            AtmFrom?.Withdraw(Amount);

            AccountTo?.Deposit(Amount);
            AtmTo?.Deposit(Amount);
        }
        catch (ValidationException ex)
        {
            OnFail(ex.Message);
            return;
        }

        OnCompletion();
    }

    private void OnCompletion()
    {
        AccountFrom?.SaveBalanceChange();
        AtmFrom?.SaveBalanceChange();
        AccountTo?.SaveBalanceChange();
        AtmTo?.SaveBalanceChange();

        ExecutedAtUtc = DateTime.UtcNow;
        Status = TransactionStatus.Completed;

        TransactionCompletedEvent?.Invoke(this, "Transaction executed successfully");
    }

    private void OnFail(string error)
    {
        AccountFrom?.CancelBalanceChange();
        AtmFrom?.CancelBalanceChange();
        AccountTo?.CancelBalanceChange();
        AtmTo?.CancelBalanceChange();

        ExecutedAtUtc = DateTime.UtcNow;
        Status = TransactionStatus.Failed;
        FailReason = error;

        TransactionFailedEvent?.Invoke(this, $"Transaction execution failed with error message: {error}");
    }
}
