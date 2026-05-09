namespace VetCareClinic.API.DTOs.Response;

public class AppointmentResponse
{
    public int Id { get; set; }

    public DateTime ScheduledAt { get; set; }

    public string Status { get; set; } = string.Empty;

    public string PetName { get; set; } = string.Empty;

    public string VeterinarianName { get; set; } = string.Empty;
}