﻿using System.Text;
using Domain.Models.Enums;
using Domain.Models.Exceptions;

namespace Domain.Models.Entities;

public class Transaction : Entity
{
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

    public bool Execute()
    {
        if (ExecutedAtUtc.HasValue)
        {
            throw new ValidationException("Transaction has been already executed");
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
            Fail(ex.Message);

            return false;
        }

        Complete();

        return true;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append(Purpose);
        stringBuilder.Append($" ${Amount}");
        stringBuilder.Append($" - {Status}");

        if (!string.IsNullOrWhiteSpace(FailReason))
        {
            stringBuilder.Append($" ({FailReason})");
        }

        if (ExecutedAtUtc.HasValue)
        {
            stringBuilder.Append($" on {ExecutedAtUtc:R}");
        }

        return stringBuilder.ToString();
    }

    public string ToStringDetailed()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(Purpose);
        stringBuilder.Append('-', Purpose.Length);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"Type: {Type}");
        stringBuilder.AppendLine($"Amount: {Amount}");
        stringBuilder.AppendLine($"Status: {Status}");

        if (!string.IsNullOrWhiteSpace(FailReason))
        {
            stringBuilder.AppendLine($"Failed reason: \"{FailReason}\"");
        }

        if (ExecutedAtUtc.HasValue)
        {
            stringBuilder.AppendLine($"Executed at: {ExecutedAtUtc:R}");
        }

        return stringBuilder.ToString();
    }


    private void Complete()
    {
        AccountFrom?.SaveBalanceChange();
        AtmFrom?.SaveBalanceChange();
        AccountTo?.SaveBalanceChange();
        AtmTo?.SaveBalanceChange();

        ExecutedAtUtc = DateTime.UtcNow;
        Status = TransactionStatus.Completed;
    }

    private void Fail(string error)
    {
        AccountFrom?.CancelBalanceChange();
        AtmFrom?.CancelBalanceChange();
        AccountTo?.CancelBalanceChange();
        AtmTo?.CancelBalanceChange();

        ExecutedAtUtc = DateTime.UtcNow;
        Status = TransactionStatus.Failed;
        FailReason = error;
    }
}
