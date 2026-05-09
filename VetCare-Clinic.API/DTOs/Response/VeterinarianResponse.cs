namespace VetCareClinic.API.DTOs.Response;

public class VeterinarianResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Specialty { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}