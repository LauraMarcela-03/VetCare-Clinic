using Microsoft.EntityFrameworkCore;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Enums;

namespace VetCareClinic.DataAccess.Seeders;

public static class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>().HasData(
            new Owner
            {
                Id = 1,
                Name = "Juan Perez",
                Phone = "3001111111",
                Email = "juan@test.com"
            },
            new Owner
            {
                Id = 2,
                Name = "Maria Gomez",
                Phone = "3002222222",
                Email = "maria@test.com"
            },
            new Owner
            {
                Id = 3,
                Name = "Carlos Ruiz",
                Phone = "3003333333",
                Email = "carlos@test.com"
            }
        );

        modelBuilder.Entity<Veterinarian>().HasData(
            new Veterinarian
            {
                Id = 1,
                Name = "Dr. Ramirez",
                Specialty = "General",
                Phone = "3101111111"
            },
            new Veterinarian
            {
                Id = 2,
                Name = "Dr. Martinez",
                Specialty = "Surgery",
                Phone = "3102222222"
            }
        );

        modelBuilder.Entity<Pet>().HasData(
            new Pet
            {
                Id = 1,
                Name = "Firulais",
                BirthDate = new DateTime(2021, 5, 10),
                Type = PetType.DOG,
                OwnerId = 1
            },
            new Pet
            {
                Id = 2,
                Name = "Misu",
                BirthDate = new DateTime(2022, 3, 15),
                Type = PetType.CAT,
                OwnerId = 2
            }
        );

        modelBuilder.Entity<Procedure>().HasData(
            new Procedure
            {
                Id = 1,
                Name = "Vaccination",
                Description = "Annual vaccination",
                Price = 50000,
                Type = ProcedureType.VACCINATION
            },
            new Procedure
            {
                Id = 2,
                Name = "Checkup",
                Description = "General health check",
                Price = 30000,
                Type = ProcedureType.CHECKUP
            }
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                Id = 1,
                PetId = 1,
                VeterinarianId = 1,
                Status = AppointmentStatus.SCHEDULED,
                ScheduledAt = new DateTime(2026, 6, 15, 10, 0, 0)
            },
            new Appointment
            {
                Id = 2,
                PetId = 2,
                VeterinarianId = 2,
                Status = AppointmentStatus.COMPLETED,
                ScheduledAt = new DateTime(2026, 5, 20, 14, 0, 0)
            }
        );

        modelBuilder.Entity<MedicalRecord>().HasData(
            new MedicalRecord
            {
                Id = 1,
                Diagnosis = "Healthy",
                Treatment = "None",
                Notes = "Routine checkup",
                Date = new DateTime(2026, 5, 20),
                PetId = 2,
                AppointmentId = 2
            }
        );

        modelBuilder.Entity<AppointmentProcedure>().HasData(
            new AppointmentProcedure
            {
                AppointmentId = 1,
                ProcedureId = 1,
                PerformedAt = new DateTime(2026, 6, 15, 10, 30, 0)
            },
            new AppointmentProcedure
            {
                AppointmentId = 2,
                ProcedureId = 2,
                PerformedAt = new DateTime(2026, 5, 20, 14, 30, 0)
            }
        );
    }
}