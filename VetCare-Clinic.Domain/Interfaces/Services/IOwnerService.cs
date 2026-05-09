using VetCareClinic.Domain.Entities;
namespace VetCareClinic.Domain.Interfaces.Services;

public interface IOwnerService
{
    Task<IEnumerable<Owner>> GetAllAsync();
    Task<Owner?> GetByIdAsync(int id);
    Task<Owner> CreateAsync(Owner owner);
    Task UpdateAsync(Owner owner);
    Task DeleteAsync(int id);
}