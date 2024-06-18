using backend.DTOs;

namespace backend.Contract;

public interface IAnimalService
{
    Task<IEnumerable<AnimalDto>> GetAllAnimalAsync(bool trackChanges);
    Task<AnimalDto> GetAnimalAsync(int animalId, bool trackChanges);
    Task<AnimalDto> CreateAnimalAsync(AnimalForCreationDto? animal);
    Task DeleteAnimalAsync(int animalId, bool trackChanges);
    Task UpdateAnimalAsync(int animalId, AnimalForUpdateDto animalForUpdate, bool trackChanges);
}