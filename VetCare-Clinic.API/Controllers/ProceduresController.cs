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
}