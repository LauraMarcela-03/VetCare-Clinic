using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCareClinic.API.DTOs.Request;
using VetCareClinic.API.DTOs.Response;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _service;

    private readonly IMapper _mapper;

    public AppointmentsController(
        IAppointmentService service,
        IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var appointments = await _service.GetAllAsync();

        return Ok(
            _mapper.Map<IEnumerable<AppointmentResponse>>(
                appointments));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var appointment = await _service.GetByIdAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        return Ok(
            _mapper.Map<AppointmentResponse>(
                appointment));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAppointmentRequest request)
    {
        var appointment =
            _mapper.Map<Appointment>(request);

        var created =
            await _service.CreateAsync(appointment);

        return Ok(
            _mapper.Map<AppointmentResponse>(created));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        CreateAppointmentRequest request)
    {
        var appointment =
            _mapper.Map<Appointment>(request);

        appointment.Id = id;

        await _service.UpdateAsync(appointment);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}