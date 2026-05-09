using VetCareClinic.Domain.Enums;

namespace VetCareClinic.API.DTOs.Request;

public class CreateProcedureRequest
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public ProcedureType Type { get; set; }
}