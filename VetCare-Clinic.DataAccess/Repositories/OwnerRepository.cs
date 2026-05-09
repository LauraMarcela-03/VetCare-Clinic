using Microsoft.EntityFrameworkCore;
using VetCareClinic.DataAccess.Context;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;

namespace VetCareClinic.DataAccess.Repositories;

public class OwnerRepository
    : GenericRepository<Owner>,
      IOwnerRepository
{
    public OwnerRepository(VetCareClinicDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<Owner>> GetAllAsync()
    {
        return await _context.Owners
            .Include(o => o.Pets)
            .ToListAsync();
    }
}
