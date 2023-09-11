using Domain.Models.Entities;
using Domain.Models.ValueObjects;
using Domain.Repositories;

namespace Domain.TestData.Database.Repositories;

public class FakeAtmRepository : IAtmRepository
{
    public AutomatedTellerMachine? GetById(Guid id)
    {
        var atm = FakeDatabase.ATMs
            .Where(x => x.Id == id)
            .SingleOrDefault();

        return atm;
    }

    public List<AutomatedTellerMachine> GetClosestByAddress(Address address)
    {
        IEnumerable<AutomatedTellerMachine> atms = FakeDatabase.ATMs;

        if (address is null)
        {
            return atms.ToList();
        }

        address.Deconstruct(
            out string street1,
            out string street2,
            out string city,
            out string state,
            out string country);

        if (!string.IsNullOrWhiteSpace(country))
        {
            atms = atms.Where(a => string.Equals(a.Address.Country, country, StringComparison.InvariantCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(state))
        {
            atms = atms.Where(a => string.Equals(a.Address.State, state, StringComparison.InvariantCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(city))
        {
            atms = atms.Where(a => string.Equals(a.Address.City, city, StringComparison.InvariantCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(street1))
        {
            atms = atms.Where(a => string.Equals(a.Address.Street1, street1, StringComparison.InvariantCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(street2))
        {
            atms = atms.Where(a => string.Equals(a.Address.Street2, street2, StringComparison.InvariantCultureIgnoreCase));
        }

        return atms.ToList();
    }
}
