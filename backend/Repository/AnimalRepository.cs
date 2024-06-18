using backend.Contract;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class AnimalRepository : BackendBase<Animal>, IAnimalRepository
{
    public AnimalRepository(BackendContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Animal>> GetAllAnimalsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Animal?> GetAnimalAsync(int raceId, bool trackChanges)
    {
        return await FindByCondition(c => c.Id.Equals(raceId), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateAnimal(Animal animal)
    {
        Create(animal);
    }

    public void DeleteAnimal(Animal animal)
    {
        Delete(animal);
    }
}