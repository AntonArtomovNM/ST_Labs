using Domain.Models.Entities;
using Domain.Models.ValueObjects;

namespace Domain.TestData.Database;

public static class FakeDatabase
{
    public static List<Bank> Banks { get; } = new List<Bank>();
    public static List<Account> Accounts { get; } = new List<Account>();
    public static List<AutomatedTellerMachine> ATMs { get; } = new List<AutomatedTellerMachine>();
    public static List<Transaction> Transactions { get; } = new List<Transaction>();

    static FakeDatabase()
    {
        // Get bank 1
        var bank1 = new Bank("Test Bank 1");

        var account1 = bank1.OpenAccount(
            new CardNumber("112233445566778899"),
            new Pincode("1234"),
            "John",
            "Doe");

        var account2 = bank1.OpenAccount(
            new CardNumber("998877665544332211"),
            new Pincode("0987"),
            "Jane",
            "Doe");

        var atm1 = bank1.OpenAtm(new Coordinates(49.84149564025544, 24.03158623791239));

        var atm2 = bank1.OpenAtm(new Coordinates(49.844772923041894, 23.996951796605273));

        var atm3 = bank1.OpenAtm(new Coordinates(49.83589178179954, 23.999746943475298));

        var atm4 = bank1.OpenAtm(new Coordinates(49.99915066097025, 36.23222726923015));

        Banks.Add(bank1);
        Accounts.AddRange(bank1.Accounts);
        ATMs.AddRange(bank1.ATMs);

        // Get bank 2
        var bank2 = new Bank("Test Bank 2");

        var account3 = bank2.OpenAccount(
            new CardNumber("123456789123456789"),
            new Pincode("4321"),
            "Don",
            "Joe");

        var account4 = bank2.OpenAccount(
            new CardNumber("987654321987654321"),
            new Pincode("7890"),
            "Donna",
            "Joe");

        var atm5 = bank2.OpenAtm(new Coordinates(49.884832, 24.087280));

        var atm6 = bank2.OpenAtm(new Coordinates(49.99795422232978, 36.238614473602375));

        var atm7 = bank2.OpenAtm(new Coordinates(50.004813208861364, 36.23222211129407));

        var atm8 = bank2.OpenAtm(new Coordinates(49.985317810149134, 36.200992486440846));

        Banks.Add(bank2);
        Accounts.AddRange(bank2.Accounts);
        ATMs.AddRange(bank2.ATMs);

        // Create transaction history
        var transaction1 = Transaction.CreateDeposit(account1, atm1, 60m);
        transaction1.Execute();
        transaction1.ExecutedAtUtc = DateTime.UtcNow.AddMonths(-2);
        Transactions.Add(transaction1);

        var transaction2 = Transaction.CreateWithdrawal(account2, atm3, 70m);
        transaction2.Execute();
        transaction2.ExecutedAtUtc = DateTime.UtcNow.AddMonths(-2);
        Transactions.Add(transaction2);

        var transaction3 = Transaction.CreateDeposit(account3, atm5, 150m);
        transaction3.Execute();
        transaction3.ExecutedAtUtc = DateTime.UtcNow.AddDays(-20);
        Transactions.Add(transaction3);

        var transaction4 = Transaction.CreateDeposit(account4, atm7, 1000m);
        transaction4.Execute();
        transaction4.ExecutedAtUtc = DateTime.UtcNow.AddDays(-20);
        Transactions.Add(transaction4);

        var transaction5 = Transaction.CreateInternal(account1, account3, 450m);
        transaction5.Execute();
        transaction5.ExecutedAtUtc = DateTime.UtcNow.AddDays(-1);
        Transactions.Add(transaction5);
    }
}
