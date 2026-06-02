using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetCare_Clinic.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "juan@test.com", "Juan Perez", "3001111111" },
                    { 2, "maria@test.com", "Maria Gomez", "3002222222" },
                    { 3, "carlos@test.com", "Carlos Ruiz", "3003333333" }
                });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "Description", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Annual vaccination", "Vaccination", 50000m, 0 },
                    { 2, "General health check", "Checkup", 30000m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Veterinarians",
                columns: new[] { "Id", "Name", "Phone", "Specialty" },
                values: new object[,]
                {
                    { 1, "Dr. Ramirez", "3101111111", "General" },
                    { 2, "Dr. Martinez", "3102222222", "Surgery" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "Name", "OwnerId", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Firulais", 1, 0 },
                    { 2, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Misu", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "PetId", "ScheduledAt", "Status", "VeterinarianId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, 2, new DateTime(2026, 5, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "AppointmentProcedures",
                columns: new[] { "AppointmentId", "ProcedureId", "PerformedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2026, 5, 20, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "AppointmentId", "Date", "Diagnosis", "Notes", "PetId", "Treatment" },
                values: new object[] { 1, 2, new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Healthy", "Routine checkup", 2, "None" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentProcedures",
                keyColumns: new[] { "AppointmentId", "ProcedureId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AppointmentProcedures",
                keyColumns: new[] { "AppointmentId", "ProcedureId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Veterinarians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Veterinarians",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
