using VetCareClinic.Domain.Enums;
namespace VetCareClinic.Domain.Entities;

public class Procedure
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProcedureType Type { get; set; }
    public ICollection<AppointmentProcedure> AppointmentProcedures { get; set; }
        = new List<AppointmentProcedure>();
}