using VetCareClinic.Domain.Entities;
namespace VetCareClinic.Domain.Interfaces.Services;

public interface IVeterinarianService
{
    Task<IEnumerable<Veterinarian>> GetAllAsync();
    Task<Veterinarian?> GetByIdAsync(int id);
    Task<Veterinarian> CreateAsync(Veterinarian veterinarian);
    Task UpdateAsync(Veterinarian veterinarian);
    Task DeleteAsync(int id);
}
