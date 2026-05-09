using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCareClinic.API.DTOs.Request;
using VetCareClinic.API.DTOs.Response;
using VetCareClinic.Domain.Entities;
using VetCareClinic.Domain.Interfaces.Services;



namespace VetCareClinic.API.Controllers;



[ApiController]
[Route("api/[controller]")]
public class OwnersController : ControllerBase
{
    private readonly IOwnerService _service;



    private readonly IMapper _mapper;



    public OwnersController(IOwnerService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var owners = await _service.GetAllAsync();



        return Ok(_mapper.Map<IEnumerable<OwnerResponse>>(owners));
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var owner = await _service.GetByIdAsync(id);



        if (owner is null)
        {
            return NotFound();
        }



        return Ok(_mapper.Map<OwnerResponse>(owner));
    }



    [HttpPost]
    public async Task<IActionResult> Create(CreateOwnerRequest request)
    {
        var owner = _mapper.Map<Owner>(request);



        var createdOwner = await _service.CreateAsync(owner);



        return Ok(_mapper.Map<OwnerResponse>(createdOwner));
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateOwnerRequest request)
    {
        var owner = _mapper.Map<Owner>(request);



        owner.Id = id;



        await _service.UpdateAsync(owner);



        return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);



        return NoContent();
    }
}