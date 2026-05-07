using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;
using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.Domain.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repository;

    public AppointmentService(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Appointment> CreateAsync(Appointment appointment)
    {
        if (appointment.ScheduledAt < DateTime.Now)
        {
            throw new Exception("Appointment date cannot be in the past");
        }

        if (appointment.PetId <= 0)
        {
            throw new Exception("Pet is required");
        }

        if (appointment.VeterinarianId <= 0)
        {
            throw new Exception("Veterinarian is required");
        }

        return await _repository.AddAsync(appointment);
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        var existingAppointment = await _repository.GetByIdAsync(appointment.Id);

        if (existingAppointment is null)
        {
            throw new Exception("Appointment not found");
        }

        existingAppointment.ScheduledAt = appointment.ScheduledAt;
        existingAppointment.Status = appointment.Status;
        existingAppointment.PetId = appointment.PetId;
        existingAppointment.VeterinarianId = appointment.VeterinarianId;

        await _repository.UpdateAsync(existingAppointment);
    }

    public async Task DeleteAsync(int id)
    {
        var existingAppointment = await _repository.GetByIdAsync(id);

        if (existingAppointment is null)
        {
            throw new Exception("Appointment not found");
        }

        await _repository.DeleteAsync(id);
    }
}