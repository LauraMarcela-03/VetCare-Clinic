namespace VetCareClinic.Domain.Interfaces.Services;

public interface IProcedureService
{
    Task<IEnumerable<Procedure>> GetAllAsync();
    Task<Procedure?> GetByIdAsync(int id);
    Task<Procedure> CreateAsync(Procedure procedure);
    Task UpdateAsync(Procedure procedure);
    Task DeleteAsync(int id);
}
