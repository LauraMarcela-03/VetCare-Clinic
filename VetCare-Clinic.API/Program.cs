using Microsoft.EntityFrameworkCore;

using VetCareClinic.API.Mappings;

using VetCareClinic.DataAccess.Context;

using VetCareClinic.DataAccess.Repositories;

using VetCareClinic.Domain.Interfaces.Repositories;

using VetCareClinic.Domain.Interfaces.Services;

using VetCareClinic.Domain.Services;

var builder = WebApplication.CreateBuilder(args);


// ── Entity Framework Core ──

builder.Services.AddDbContext<VetCareClinicDbContext>(options =>

    options.UseSqlServer(

        builder.Configuration.GetConnectionString("DefaultConnection")));


// ── Repositories ──

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IPetRepository, PetRepository>();

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();

builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();


// ── Services ──

builder.Services.AddScoped<IPetService, PetService>();

builder.Services.AddScoped<IOwnerService, OwnerService>();

builder.Services.AddScoped<IProcedureService, ProcedureService>();

builder.Services.AddScoped<IVeterinarianService, VeterinarianService>();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();


// ── AutoMapper ──

builder.Services.AddAutoMapper(typeof(Program).Assembly);


// ── Controllers ──

builder.Services.AddControllers();


// ── Swagger ──

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


var app = builder.Build();


// ── Middleware Pipeline ──

if (app.Environment.IsDevelopment())

{
    app.UseSwagger();

    app.UseSwaggerUI();
}


app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
