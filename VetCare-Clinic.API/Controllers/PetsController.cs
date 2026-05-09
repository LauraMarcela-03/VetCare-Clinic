using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCareClinic.API.DTOs.Request;
using VetCareClinic.API.DTOs.Response;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    private readonly IPetService _service;

    private readonly IMapper _mapper;

    public PetsController(IPetService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pets = await _service.GetAllAsync();

        return Ok(_mapper.Map<IEnumerable<PetResponse>>(pets));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pet = await _service.GetByIdAsync(id);

        if (pet is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PetResponse>(pet));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePetRequest request)
    {
        var pet = _mapper.Map<Pet>(request);

        var createdPet = await _service.CreateAsync(pet);

        return Ok(_mapper.Map<PetResponse>(createdPet));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreatePetRequest request)
    {
        var pet = _mapper.Map<Pet>(request);

        pet.Id = id;

        await _service.UpdateAsync(pet);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}