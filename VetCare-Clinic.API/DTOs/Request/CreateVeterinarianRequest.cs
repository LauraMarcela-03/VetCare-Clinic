namespace VetCareClinic.API.DTOs.Request;

public class CreateVeterinarianRequest
{
    public string Name { get; set; } = string.Empty;

    public string Specialty { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}