using AutoMapper;
using VetCareClinic.API.DTOs.Request;
using VetCareClinic.API.DTOs.Response;
using VetCareClinic.Domain.Entities;



namespace VetCareClinic.API.Mappings;



public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // =====================================================
        // REQUEST -> ENTITY
        // =====================================================



        CreateMap<CreateOwnerRequest, Owner>();



        CreateMap<CreatePetRequest, Pet>();



        CreateMap<CreateProcedureRequest, Procedure>();



        CreateMap<CreateVeterinarianRequest, Veterinarian>();



        CreateMap<CreateAppointmentRequest, Appointment>();



        CreateMap<CreateMedicalRecordRequest, MedicalRecord>();





        // =====================================================
        // ENTITY -> RESPONSE
        // =====================================================



        CreateMap<Owner, OwnerResponse>();





        CreateMap<Pet, PetResponse>()
        .ForMember(
        dest => dest.Type,
        opt => opt.MapFrom(src => src.Type.ToString()))
        .ForMember(
        dest => dest.OwnerName,
        opt => opt.MapFrom(src =>
        src.Owner != null
        ? src.Owner.Name
        : string.Empty));





        CreateMap<Procedure, ProcedureResponse>()
        .ForMember(
        dest => dest.Type,
        opt => opt.MapFrom(src => src.Type.ToString()));





        CreateMap<Veterinarian, VeterinarianResponse>();





        CreateMap<Appointment, AppointmentResponse>()
        .ForMember(
        dest => dest.Status,
        opt => opt.MapFrom(src => src.Status.ToString()))
        .ForMember(
        dest => dest.PetName,
        opt => opt.MapFrom(src =>
        src.Pet != null
        ? src.Pet.Name
        : string.Empty))
        .ForMember(
        dest => dest.VeterinarianName,
        opt => opt.MapFrom(src =>
        src.Veterinarian != null
        ? src.Veterinarian.Name
        : string.Empty));





        CreateMap<MedicalRecord, MedicalRecordResponse>()
        .ForMember(
        dest => dest.PetName,
        opt => opt.MapFrom(src =>
        src.Pet != null
        ? src.Pet.Name
        : string.Empty));





        CreateMap<AppointmentProcedure, AppointmentProcedureResponse>()
        .ForMember(
        dest => dest.ProcedureName,
        opt => opt.MapFrom(src =>
        src.Procedure != null
        ? src.Procedure.Name
        : string.Empty));





        // =====================================================
        // OPTIONAL BIDIRECTIONAL MAPPINGS
        // =====================================================



        CreateMap<OwnerResponse, Owner>();



        CreateMap<PetResponse, Pet>();



        CreateMap<ProcedureResponse, Procedure>();



        CreateMap<VeterinarianResponse, Veterinarian>();



        CreateMap<AppointmentResponse, Appointment>();



        CreateMap<MedicalRecordResponse, MedicalRecord>();
    }
}