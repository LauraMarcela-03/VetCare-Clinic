using Microsoft.EntityFrameworkCore;
using VetCareClinic.DataAccess.Context;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;

namespace VetCareClinic.DataAccess.Repositories;

public class MedicalRecordRepository
    : GenericRepository<MedicalRecord>,
      IMedicalRecordRepository
{
    public MedicalRecordRepository(
        VetCareClinicDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<MedicalRecord>> GetAllAsync()
    {
        return await _context.MedicalRecords
            .Include(m => m.Pet)
            .Include(m => m.Appointment)
            .ToListAsync();
    }
}