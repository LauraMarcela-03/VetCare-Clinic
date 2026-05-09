using VetCareClinic.Domain.Enums;
namespace VetCareClinic.Domain.Entities;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public PetType Type { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}
