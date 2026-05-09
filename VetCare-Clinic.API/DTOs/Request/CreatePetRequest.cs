using VetCareClinic.Domain.Enums;

namespace VetCareClinic.API.DTOs.Request;

public class CreatePetRequest

{

    public string Name { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public PetType Type { get; set; }

    public int OwnerId { get; set; }

}
