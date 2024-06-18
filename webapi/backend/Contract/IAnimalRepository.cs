using backend.Models;

namespace backend.Contract;

public interface IAnimalRepository
{
    Task<IEnumerable<Animal>> GetAllAnimalsAsync(bool trackChanges);
    Task<Animal?> GetAnimalAsync(int raceId, bool trackChanges);
    void CreateAnimal(Animal race);
    void DeleteAnimal(Animal race);
}