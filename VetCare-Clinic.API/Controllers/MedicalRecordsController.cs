using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCareClinic.API.DTOs.Request;
using VetCareClinic.API.DTOs.Response;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalRecordsController : ControllerBase
{
    private readonly IMedicalRecordService _service;

    private readonly IMapper _mapper;

    public MedicalRecordsController(
        IMedicalRecordService service,
        IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var medicalRecords =
            await _service.GetAllAsync();

        return Ok(
            _mapper.Map<IEnumerable<MedicalRecordResponse>>(
                medicalRecords));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var medicalRecord =
            await _service.GetByIdAsync(id);

        if (medicalRecord is null)
        {
            return NotFound();
        }

        return Ok(
            _mapper.Map<MedicalRecordResponse>(
                medicalRecord));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateMedicalRecordRequest request)
    {
        var medicalRecord =
            _mapper.Map<MedicalRecord>(request);

        var created =
            await _service.CreateAsync(medicalRecord);

        return Ok(
            _mapper.Map<MedicalRecordResponse>(
                created));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        CreateMedicalRecordRequest request)
    {
        var medicalRecord =
            _mapper.Map<MedicalRecord>(request);

        medicalRecord.Id = id;

        await _service.UpdateAsync(medicalRecord);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}