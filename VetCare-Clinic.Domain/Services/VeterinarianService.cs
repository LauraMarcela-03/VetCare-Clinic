using VetCareClinic.Domain.Entities;

using VetCareClinic.Domain.Interfaces.Repositories;

using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.Domain.Services;

public class VeterinarianService : IVeterinarianService

{

    private readonly IVeterinarianRepository _repository;

    public VeterinarianService(IVeterinarianRepository repository)

    {

        _repository = repository;

    }

    public async Task<IEnumerable<Veterinarian>> GetAllAsync()

    {

        return await _repository.GetAllAsync();

    }

    public async Task<Veterinarian?> GetByIdAsync(int id)

    {

        return await _repository.GetByIdAsync(id);

    }

    public async Task<Veterinarian> CreateAsync(Veterinarian veterinarian)

    {

        if (string.IsNullOrWhiteSpace(veterinarian.Name))

        {

            throw new Exception("Veterinarian name is required");

        }

        return await _repository.AddAsync(veterinarian);

    }

    public async Task UpdateAsync(Veterinarian veterinarian)

    {

        var existingVeterinarian = await _repository.GetByIdAsync(veterinarian.Id);

        if (existingVeterinarian is null)

        {

            throw new Exception("Veterinarian not found");

        }

        existingVeterinarian.Name = veterinarian.Name;

        existingVeterinarian.Specialty = veterinarian.Specialty;

        existingVeterinarian.Phone = veterinarian.Phone;

        await _repository.UpdateAsync(existingVeterinarian);

    }

    public async Task DeleteAsync(int id)

    {

        var existingVeterinarian = await _repository.GetByIdAsync(id);

        if (existingVeterinarian is null)

        {

            throw new Exception("Veterinarian not found");

        }

        await _repository.DeleteAsync(id);

    }

}
