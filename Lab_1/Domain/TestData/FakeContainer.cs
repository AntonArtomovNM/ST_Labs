using Domain.Repositories;
using Domain.Services.Accounts;
using Domain.Services.ATMs;
using Domain.Services.EmailSending;
using Domain.Services.Transactions;
using Domain.TestData.Database.Repositories;

namespace Domain.TestData;

public static class FakeContainer
{
    public static ITransactionRepository TransactionRepository { get; }

    public static IAccountRepository AccountRepository { get; }

    public static IAtmRepository AtmRepository { get; }

    public static IAccountManagementService AccountManagementService { get; }

    public static IAtmManagementService AtmManagementService { get; }

    public static ITransactionManagementService TransactionManagementService { get; }

    public static IEmailSendingService EmailSendingService { get; }

    static FakeContainer()
    {
        TransactionRepository = new FakeTransactionsRepository();
        AccountRepository = new FakeAccountsRepository();
        AtmRepository = new FakeAtmRepository();

        AccountManagementService = new AccountManagementService(AccountRepository);
        AtmManagementService = new AtmManagementService(AtmRepository);
        TransactionManagementService = new TransactionManagementService(TransactionRepository, AccountRepository, AtmRepository);

        EmailSendingService = new SmtpEmailSendingService();
    }
}
