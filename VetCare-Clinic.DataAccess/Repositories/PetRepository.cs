using Microsoft.EntityFrameworkCore;
using VetCareClinic.DataAccess.Context;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;

namespace VetCareClinic.DataAccess.Repositories;

public class PetRepository
    : GenericRepository<Pet>,
      IPetRepository
{
    public PetRepository(VetCareClinicDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await _context.Pets
            .Include(p => p.Owner)
            .Include(p => p.Appointments)
            .Include(p => p.MedicalRecords)
            .ToListAsync();
    }
}