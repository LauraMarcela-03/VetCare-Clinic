using Microsoft.EntityFrameworkCore;
using VetCareClinic.DataAccess.Context;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;

namespace VetCareClinic.DataAccess.Repositories;

public class AppointmentProcedureRepository
    : GenericRepository<AppointmentProcedure>,
      IAppointmentProcedureRepository
{
    public AppointmentProcedureRepository(
        VetCareClinicDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<AppointmentProcedure>> GetAllAsync()
    {
        return await _context.AppointmentProcedures
            .Include(ap => ap.Appointment)
            .Include(ap => ap.Procedure)
            .ToListAsync();
    }
}