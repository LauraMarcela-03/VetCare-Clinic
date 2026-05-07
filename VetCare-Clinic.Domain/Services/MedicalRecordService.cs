using VetCareClinic.Domain.Entities;

using VetCareClinic.Domain.Interfaces.Repositories;

using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.Domain.Services;

public class MedicalRecordService : IMedicalRecordService

{

    private readonly IMedicalRecordRepository _repository;

    public MedicalRecordService(IMedicalRecordRepository repository)

    {

        _repository = repository;

    }

    public async Task<IEnumerable<MedicalRecord>> GetAllAsync()

    {

        return await _repository.GetAllAsync();

    }

    public async Task<MedicalRecord?> GetByIdAsync(int id)

    {

        return await _repository.GetByIdAsync(id);

    }

    public async Task<MedicalRecord> CreateAsync(MedicalRecord medicalRecord)

    {

        if (string.IsNullOrWhiteSpace(medicalRecord.Diagnosis))

        {

            throw new Exception("Diagnosis is required");

        }

        return await _repository.AddAsync(medicalRecord);

    }

    public async Task UpdateAsync(MedicalRecord medicalRecord)

    {

        var existingMedicalRecord = await _repository.GetByIdAsync(medicalRecord.Id);

        if (existingMedicalRecord is null)

        {

            throw new Exception("Medical record not found");

        }

        existingMedicalRecord.Diagnosis = medicalRecord.Diagnosis;

        existingMedicalRecord.Treatment = medicalRecord.Treatment;

        existingMedicalRecord.Notes = medicalRecord.Notes;

        existingMedicalRecord.Date = medicalRecord.Date;

        await _repository.UpdateAsync(existingMedicalRecord);

    }

    public async Task DeleteAsync(int id)

    {

        var existingMedicalRecord = await _repository.GetByIdAsync(id);

        if (existingMedicalRecord is null)

        {

            throw new Exception("Medical record not found");

        }

        await _repository.DeleteAsync(id);

    }

}
