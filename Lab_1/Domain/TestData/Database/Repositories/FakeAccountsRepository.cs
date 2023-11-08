using Domain.Models.Entities;
using Domain.Models.ValueObjects;
using Domain.Repositories;

namespace Domain.TestData.Database.Repositories;

public class FakeAccountsRepository : IAccountRepository
{
    public Account? GetByCardNumber(CardNumber cardNumber)
    {
        Account? account = FakeDatabase.Accounts
            .Where(a => a.CardNumber == cardNumber)
            .SingleOrDefault();

        return account;
    }
}
