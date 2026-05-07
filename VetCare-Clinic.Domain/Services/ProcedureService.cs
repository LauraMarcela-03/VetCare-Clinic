using VetCareClinic.Domain.Entities;

using VetCareClinic.Domain.Interfaces.Repositories;

using VetCareClinic.Domain.Interfaces.Services;

namespace VetCareClinic.Domain.Services;

public class ProcedureService : IProcedureService

{

    private readonly IProcedureRepository _repository;

    public ProcedureService(IProcedureRepository repository)

    {

        _repository = repository;

    }

    public async Task<IEnumerable<Procedure>> GetAllAsync()

    {

        return await _repository.GetAllAsync();

    }

    public async Task<Procedure?> GetByIdAsync(int id)

    {

        return await _repository.GetByIdAsync(id);

    }

    public async Task<Procedure> CreateAsync(Procedure procedure)

    {

        if (string.IsNullOrWhiteSpace(procedure.Name))

        {

            throw new Exception("Procedure name is required");

        }

        if (procedure.Price < 0)

        {

            throw new Exception("Price cannot be negative");

        }

        return await _repository.AddAsync(procedure);

    }

    public async Task UpdateAsync(Procedure procedure)

    {

        var existingProcedure = await _repository.GetByIdAsync(procedure.Id);

        if (existingProcedure is null)

        {

            throw new Exception("Procedure not found");

        }

        existingProcedure.Name = procedure.Name;

        existingProcedure.Description = procedure.Description;

        existingProcedure.Price = procedure.Price;

        existingProcedure.Type = procedure.Type;

        await _repository.UpdateAsync(existingProcedure);

    }

    public async Task DeleteAsync(int id)

    {

        var existingProcedure = await _repository.GetByIdAsync(id);

        if (existingProcedure is null)

        {

            throw new Exception("Procedure not found");

        }

        await _repository.DeleteAsync(id);

    }

}
