using VetCareClinic.Domain.Enums;

namespace VetCareClinic.API.DTOs.Request;

public class CreateAppointmentRequest
{
    public DateTime ScheduledAt { get; set; }

    public AppointmentStatus Status { get; set; }

    public int PetId { get; set; }

    public int VeterinarianId { get; set; }
}