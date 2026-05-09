namespace VetCareClinic.API.DTOs.Response;

public class ProcedureResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Type { get; set; } = string.Empty;
}