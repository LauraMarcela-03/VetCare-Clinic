using VetCareClinic.Domain.Enums;
namespace VetCareClinic.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public DateTime ScheduledAt { get; set; }
    public AppointmentStatus Status { get; set; }
    public int PetId { get; set; }
    public Pet Pet { get; set; } = null!;
    public int VeterinarianId { get; set; }
    public Veterinarian Veterinarian { get; set; } = null!;
    public MedicalRecord? MedicalRecord { get; set; }
    public ICollection<AppointmentProcedure> AppointmentProcedures { get; set; } = new List<AppointmentProcedure>();
}
