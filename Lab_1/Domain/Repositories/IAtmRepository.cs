using Domain.Models.Entities;
using Domain.Models.ValueObjects;

namespace Domain.Repositories;

public interface IAtmRepository
{
    AutomatedTellerMachine? GetById(Guid id);

    AutomatedTellerMachine? GetClosestByCoordinates(Coordinates coordinates);
}
