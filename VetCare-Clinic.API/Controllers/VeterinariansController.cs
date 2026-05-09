using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using VetCareClinic.API.DTOs.Request;

using VetCareClinic.API.DTOs.Response;

using VetCareClinic.Domain.Entities;

using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.API.Controllers;

[ApiController]

[Route("api/[controller]")]

public class VeterinariansController : ControllerBase

{

    private readonly IVeterinarianService _service;

    private readonly IMapper _mapper;

    public VeterinariansController(

        IVeterinarianService service,

        IMapper mapper)

    {

        _service = service;

        _mapper = mapper;

    }

    [HttpGet]

    public async Task<IActionResult> GetAll()

    {

        var veterinarians = await _service.GetAllAsync();

        return Ok(

            _mapper.Map<IEnumerable<VeterinarianResponse>>(

                veterinarians));

    }

    [HttpPost]

    public async Task<IActionResult> Create(

        CreateVeterinarianRequest request)

    {

        var veterinarian = _mapper.Map<Veterinarian>(request);

        var created =

            await _service.CreateAsync(veterinarian);

        return Ok(

            _mapper.Map<VeterinarianResponse>(created));

    }

}
