using VetCareClinic.Domain.Entities;
namespace VetCareClinic.Domain.Interfaces.Services;

public interface IMedicalRecordService
{
    Task<IEnumerable<MedicalRecord>> GetAllAsync();
    Task<MedicalRecord?> GetByIdAsync(int id);
    Task<MedicalRecord> CreateAsync(MedicalRecord medicalRecord);
    Task UpdateAsync(MedicalRecord medicalRecord);
    Task DeleteAsync(int id);
}
