using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;
using VetCareClinic.Domain.Interfaces.Services;
namespace VetCareClinic.Domain.Services;

public class PetService : IPetService
{

    private readonly IPetRepository _repository;

    public PetService(IPetRepository repository)

    {

        _repository = repository;

    }

    public async Task<IEnumerable<Pet>> GetAllAsync()

    {

        return await _repository.GetAllAsync();

    }

    public async Task<Pet?> GetByIdAsync(int id)

    {

        return await _repository.GetByIdAsync(id);

    }

    public async Task<Pet> CreateAsync(Pet pet)

    {

        if (string.IsNullOrWhiteSpace(pet.Name))

        {

            throw new Exception("Pet name is required");

        }

        if (pet.OwnerId <= 0)

        {

            throw new Exception("Owner is required");

        }

        if (pet.BirthDate > DateTime.Now)

        {

            throw new Exception("Birth date cannot be in the future");

        }

        return await _repository.AddAsync(pet);

    }

    public async Task UpdateAsync(Pet pet)

    {

        var existingPet = await _repository.GetByIdAsync(pet.Id);

        if (existingPet is null)

        {

            throw new Exception("Pet not found");

        }

        if (string.IsNullOrWhiteSpace(pet.Name))

        {

            throw new Exception("Pet name is required");

        }

        if (pet.OwnerId <= 0)

        {

            throw new Exception("Owner is required");

        }

        existingPet.Name = pet.Name;

        existingPet.BirthDate = pet.BirthDate;

        existingPet.Type = pet.Type;

        existingPet.OwnerId = pet.OwnerId;

        await _repository.UpdateAsync(existingPet);

    }

    public async Task DeleteAsync(int id)

    {

        var existingPet = await _repository.GetByIdAsync(id);

        if (existingPet is null)

        {

            throw new Exception("Pet not found");

        }

        await _repository.DeleteAsync(id);

    }

}

