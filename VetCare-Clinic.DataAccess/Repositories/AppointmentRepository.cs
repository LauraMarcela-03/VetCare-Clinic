using Microsoft.EntityFrameworkCore;
using VetCareClinic.DataAccess.Context;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Repositories;

namespace VetCareClinic.DataAccess.Repositories;

public class AppointmentRepository
    : GenericRepository<Appointment>,
      IAppointmentRepository
{
    public AppointmentRepository(
        VetCareClinicDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _context.Appointments
            .Include(a => a.Pet)
            .Include(a => a.Veterinarian)
            .Include(a => a.MedicalRecord)
            .Include(a => a.AppointmentProcedures)
                .ThenInclude(ap => ap.Procedure)
            .ToListAsync();
    }
}