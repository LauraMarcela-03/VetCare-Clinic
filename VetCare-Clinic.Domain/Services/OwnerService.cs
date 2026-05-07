using VetCareClinic.Domain.Entities;

using VetCareClinic.Domain.Interfaces.Repositories;

using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.Domain.Services;

public class OwnerService : IOwnerService

{

    private readonly IOwnerRepository _repository;

    public OwnerService(IOwnerRepository repository)

    {

        _repository = repository;

    }

    public async Task<IEnumerable<Owner>> GetAllAsync()

    {

        return await _repository.GetAllAsync();

    }

    public async Task<Owner?> GetByIdAsync(int id)

    {

        return await _repository.GetByIdAsync(id);

    }

    public async Task<Owner> CreateAsync(Owner owner)

    {

        if (string.IsNullOrWhiteSpace(owner.Name))

        {

            throw new Exception("Owner name is required");

        }

        return await _repository.AddAsync(owner);

    }

    public async Task UpdateAsync(Owner owner)

    {

        var existingOwner = await _repository.GetByIdAsync(owner.Id);

        if (existingOwner is null)

        {

            throw new Exception("Owner not found");

        }

        existingOwner.Name = owner.Name;

        existingOwner.Phone = owner.Phone;

        existingOwner.Email = owner.Email;

        await _repository.UpdateAsync(existingOwner);

    }

    public async Task DeleteAsync(int id)

    {

        var existingOwner = await _repository.GetByIdAsync(id);

        if (existingOwner is null)

        {

            throw new Exception("Owner not found");

        }

        await _repository.DeleteAsync(id);

    }

}
