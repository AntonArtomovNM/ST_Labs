using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Domain.Repositories;

public interface ITransactionRepository
{
    void Create(Transaction transaction);

    List<Transaction> GetByAccountIdWithinTimeRange(Guid accountId, TimeRangeOption timeRange);
}
