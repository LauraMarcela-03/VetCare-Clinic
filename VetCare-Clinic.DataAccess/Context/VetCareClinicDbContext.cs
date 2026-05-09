using Microsoft.EntityFrameworkCore;

using VetCareClinic.Domain.Entities;

namespace VetCareClinic.DataAccess.Context;

public class VetCareClinicDbContext : DbContext

{

    public VetCareClinicDbContext(

        DbContextOptions<VetCareClinicDbContext> options)

        : base(options)

    {

    }

    // =====================================================

    // TABLES

    // =====================================================

    public DbSet<Owner> Owners { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<Veterinarian> Veterinarians { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    public DbSet<Procedure> Procedures { get; set; }

    public DbSet<AppointmentProcedure> AppointmentProcedures { get; set; }


    // =====================================================

    // RELATIONSHIPS

    // =====================================================

    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {

        base.OnModelCreating(modelBuilder);


        // -------------------------------------------------

        // OWNER -> PET

        // One Owner has many Pets

        // -------------------------------------------------

        modelBuilder.Entity<Pet>()

            .HasOne(p => p.Owner)

            .WithMany(o => o.Pets)

            .HasForeignKey(p => p.OwnerId);


        // -------------------------------------------------

        // PET -> APPOINTMENT

        // One Pet has many Appointments

        // -------------------------------------------------

        modelBuilder.Entity<Appointment>()

            .HasOne(a => a.Pet)

            .WithMany(p => p.Appointments)

            .HasForeignKey(a => a.PetId);


        // -------------------------------------------------

        // VETERINARIAN -> APPOINTMENT

        // One Veterinarian has many Appointments

        // -------------------------------------------------

        modelBuilder.Entity<Appointment>()

            .HasOne(a => a.Veterinarian)

            .WithMany(v => v.Appointments)

            .HasForeignKey(a => a.VeterinarianId);


        // -------------------------------------------------

        // APPOINTMENT -> MEDICAL RECORD

        // One Appointment has one MedicalRecord

        // -------------------------------------------------

        modelBuilder.Entity<MedicalRecord>()

            .HasOne(m => m.Appointment)

            .WithOne(a => a.MedicalRecord)

            .HasForeignKey<MedicalRecord>(m => m.AppointmentId);


        // -------------------------------------------------

        // PET -> MEDICAL RECORD

        // One Pet has many MedicalRecords

        // -------------------------------------------------

        modelBuilder.Entity<MedicalRecord>()
    .HasOne(m => m.Pet)
    .WithMany(p => p.MedicalRecords)
    .HasForeignKey(m => m.PetId)
    .OnDelete(DeleteBehavior.NoAction);


        // -------------------------------------------------

        // APPOINTMENT <-> PROCEDURE

        // Many to Many

        // -------------------------------------------------

        modelBuilder.Entity<AppointmentProcedure>()

            .HasKey(ap => new

            {

                ap.AppointmentId,

                ap.ProcedureId

            });


        modelBuilder.Entity<AppointmentProcedure>()

            .HasOne(ap => ap.Appointment)

            .WithMany(a => a.AppointmentProcedures)

            .HasForeignKey(ap => ap.AppointmentId);


        modelBuilder.Entity<AppointmentProcedure>()

            .HasOne(ap => ap.Procedure)

            .WithMany(p => p.AppointmentProcedures)

            .HasForeignKey(ap => ap.ProcedureId);

    }

}
