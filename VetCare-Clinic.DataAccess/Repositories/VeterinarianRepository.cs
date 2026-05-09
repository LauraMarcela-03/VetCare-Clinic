using Microsoft.EntityFrameworkCore;
using VetCareClinic.DataAccess.Context;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;

namespace VetCareClinic.DataAccess.Repositories;

public class VeterinarianRepository
    : GenericRepository<Veterinarian>,
      IVeterinarianRepository
{
    public VeterinarianRepository(
        VetCareClinicDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<Veterinarian>> GetAllAsync()
    {
        return await _context.Veterinarians
            .Include(v => v.Appointments)
            .ToListAsync();
    }
}