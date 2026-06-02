using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCareClinic.API.DTOs.Request;
using VetCareClinic.API.DTOs.Response;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProceduresController : ControllerBase
{
    private readonly IProcedureService _service;

    private readonly IMapper _mapper;

    public ProceduresController(IProcedureService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var procedures = await _service.GetAllAsync();

        return Ok(_mapper.Map<IEnumerable<ProcedureResponse>>(procedures));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProcedureRequest request)
    {
        var procedure = _mapper.Map<Procedure>(request);

        var createdProcedure = await _service.CreateAsync(procedure);

        return Ok(_mapper.Map<ProcedureResponse>(createdProcedure));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var procedure = await _service.GetByIdAsync(id);
        if (procedure is null)
            return NotFound();
        return Ok(
            _mapper.Map<ProcedureResponse>(procedure));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        CreateProcedureRequest request)
    {
        var procedure =
            _mapper.Map<Procedure>(request);
        procedure.Id = id;
        await _service.UpdateAsync(procedure);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}