using VetCareClinic.Domain.Entities;
namespace VetCareClinic.Domain.Interfaces.Services;

public interface IPetService
{
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> CreateAsync(Pet pet);
    Task UpdateAsync(Pet pet);
    Task DeleteAsync(int id);
}