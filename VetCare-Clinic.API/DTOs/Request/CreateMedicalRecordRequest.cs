namespace VetCareClinic.API.DTOs.Request;

public class CreateMedicalRecordRequest
{
    public string Diagnosis { get; set; } = string.Empty;

    public string Treatment { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public int PetId { get; set; }

    public int AppointmentId { get; set; }
}