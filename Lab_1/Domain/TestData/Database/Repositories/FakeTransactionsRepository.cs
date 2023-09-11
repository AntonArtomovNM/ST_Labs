using Domain.Models.Entities;
using Domain.Models.Enums;
using Domain.Repositories;

namespace Domain.TestData.Database.Repositories;
public class FakeTransactionsRepository : ITransactionRepository
{
    public void Create(Transaction transaction)
    {
        FakeDatabase.Transactions.Add(transaction);
    }

    public List<Transaction> GetByAccountIdWithinTimeRange(Guid accountId, TimeRangeOption timeRange)
    {
        var accountTransactions = FakeDatabase.Transactions
            .Where(t => t.AccountFrom?.Id == accountId || t.AccountTo?.Id == accountId)
            .OrderByDescending(t => t.ExecutedAtUtc);

        var currentDate = DateTime.UtcNow.Date;

        return timeRange switch
        {
            TimeRangeOption.None => accountTransactions.ToList(),
            TimeRangeOption.Day => accountTransactions.Where(t => t.ExecutedAtUtc >= currentDate).ToList(),
            TimeRangeOption.Week => accountTransactions.Where(t => t.ExecutedAtUtc >= currentDate.AddDays(-7)).ToList(),
            TimeRangeOption.Month => accountTransactions.Where(t => t.ExecutedAtUtc >= currentDate.AddMonths(-1)).ToList(),
            _ => throw new ArgumentOutOfRangeException(nameof(timeRange)),
        };
    }
}
