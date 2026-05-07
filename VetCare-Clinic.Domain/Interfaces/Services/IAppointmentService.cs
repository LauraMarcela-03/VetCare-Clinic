using VetCareClinic.Domain.Entities;
namespace VetCareClinic.Domain.Interfaces.Services;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task<Appointment?> GetByIdAsync(int id);
    Task<Appointment> CreateAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(int id);
}