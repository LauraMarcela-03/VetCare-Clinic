namespace VetCareClinic.API.DTOs.Response;

public class PetResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string OwnerName { get; set; } = string.Empty;
}