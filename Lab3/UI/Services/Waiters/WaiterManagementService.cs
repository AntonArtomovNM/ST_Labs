using Domain.Entities;
using Domain.Repositories;
using UI.Models;

namespace UI.Services.Waiters;

public class WaiterManagementService : IWaiterManagementService
{
    private readonly IWaiterRepository _waiterRepository;

    public WaiterManagementService(IWaiterRepository waiterRepository)
    {
        _waiterRepository = waiterRepository;
    }

    public async Task<WaiterDto> Add(WaiterDto waiter)
    {
        if (waiter is null)
        {
            throw new ArgumentNullException(nameof(waiter));
        }

        Waiter entity = MapToEntity(waiter);

        await _waiterRepository.Add(entity);

        return WaiterDto.FromEntity(entity);
    }

    public async Task<WaiterDto> Update(WaiterDto waiter)
    {
        if (waiter is null)
        {
            throw new ArgumentNullException(nameof(waiter));
        }

        if (waiter.Id is null)
        {
            throw new ArgumentNullException("waiter.Id");
        }

        var entity = await _waiterRepository.Get(waiter.Id.Value);

        if (entity is null)
        {
            throw new ArgumentException($"Waiter with id {waiter.Id} not found");
        }

        entity = MapToEntity(waiter, entity);

        await _waiterRepository.Update(entity);

        return WaiterDto.FromEntity(entity);
    }

    public async Task<bool> Remove(WaiterDto waiter)
    {
        if (waiter is null)
        {
            throw new ArgumentNullException(nameof(waiter));
        }

        if (waiter.Id is null)
        {
            throw new ArgumentNullException("waiter.Id");
        }

        return await _waiterRepository.Remove(waiter.Id.Value);
    }

    public async Task<IList<WaiterDto>> GetAll()
    {
        var entities = await _waiterRepository.GetAll();

        return entities
            .Select(WaiterDto.FromEntity)
            .ToList();
    }

    public async Task<WaiterDto?> GetDetails(int id)
    {
        var entity = await _waiterRepository.Get(id, shouldLoadCustomers: true);

        if (entity is null)
        {
            return null;
        }

        var waiterDto = WaiterDto.FromEntity(entity);

        var customerDtos = entity.Customers.Select(CustomerDto.FromEntity);
        waiterDto.SetCustomers(customerDtos);

        return waiterDto;
    }

    private Waiter MapToEntity(WaiterDto dto)
    {
        var entity = new Waiter(
            dto.FirstName,
            dto.LastName,
            dto.PhoneNumber,
            dto.DateOfBirth,
            dto.Salary,
            dto.Rating);

        return entity;
    }

    private Waiter MapToEntity(WaiterDto dto, Waiter entity)
    {
        entity.FirstName = dto.FirstName;
        entity.LastName = dto.LastName;
        entity.PhoneNumber = dto.PhoneNumber;
        entity.DateOfBirth = dto.DateOfBirth;
        entity.Salary = dto.Salary;
        entity.Rating = dto.Rating;

        return entity;
    }
}
