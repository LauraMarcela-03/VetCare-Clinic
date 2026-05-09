namespace VetCareClinic.API.DTOs.Response;

public class MedicalRecordResponse
{
    public int Id { get; set; }

    public string Diagnosis { get; set; } = string.Empty;

    public string Treatment { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public string PetName { get; set; } = string.Empty;
}