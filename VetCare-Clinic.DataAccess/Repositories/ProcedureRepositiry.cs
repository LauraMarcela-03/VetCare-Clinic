using Microsoft.EntityFrameworkCore;
using VetCareClinic.DataAccess.Context;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;

namespace VetCareClinic.DataAccess.Repositories;

public class ProcedureRepository
    : GenericRepository<Procedure>,
      IProcedureRepository
{
    public ProcedureRepository(VetCareClinicDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<Procedure>> GetAllAsync()
    {
        return await _context.Procedures
            .Include(p => p.AppointmentProcedures)
            .ToListAsync();
    }
}