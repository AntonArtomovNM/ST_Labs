using Domain.Models.Entities;
using Domain.Models.ValueObjects;

namespace Domain.Repositories;

public interface IAccountRepository
{
    Account? GetByCardNumber(CardNumber cardNumber);
}
