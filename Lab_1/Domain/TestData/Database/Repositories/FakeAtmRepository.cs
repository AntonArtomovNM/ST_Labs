using Domain.Models.Entities;
using Domain.Models.ValueObjects;
using Domain.Repositories;

namespace Domain.TestData.Database.Repositories;

public class FakeAtmRepository : IAtmRepository
{
    public AutomatedTellerMachine? GetById(Guid id)
    {
        AutomatedTellerMachine? atm = FakeDatabase.ATMs
            .Where(x => x.Id == id)
            .SingleOrDefault();

        return atm;
    }

    public AutomatedTellerMachine? GetClosestByCoordinates(Coordinates coordinates)
    {
        IEnumerable<AutomatedTellerMachine> atms = FakeDatabase.ATMs
            .OrderBy(a => a.Coordinates.GetDistanceTo(coordinates));

        return atms.FirstOrDefault();
    }
}
