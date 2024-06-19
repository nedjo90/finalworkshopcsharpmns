using AutoMapper;
using backend.Contract;
using backend.DTOs;
using backend.Exceptions;
using backend.Models;

namespace backend.Services;

public class AnimalService : IAnimalService
{
    private readonly IBackendManager _backendManager;
    private readonly IMapper _mapper;

    public AnimalService(IBackendManager backendManager, IMapper mapper)
    {
        _backendManager = backendManager;
        _mapper = mapper;
    }

    private async Task<Animal> GetAnimalAndCheckIfItExists(int animalId, bool trackChanges)
    {
        Animal? animal = await _backendManager.Animal.GetAnimalAsync(animalId, trackChanges);
        if (animal is null)
        {
            throw new AnimalNotFoundException(animalId);
        }

        return animal;
    }

    public async Task<IEnumerable<AnimalDto>> GetAllAnimalAsync(bool trackChanges)
    {
        IEnumerable<Animal> animals = await _backendManager.Animal.GetAllAnimalsAsync(trackChanges);
        IEnumerable<AnimalDto>? racesDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
        return racesDto;
    }

    public async Task<AnimalDto> GetAnimalAsync(int animalId, bool trackChanges)
    {
        Animal animal = await GetAnimalAndCheckIfItExists(animalId, trackChanges);
        AnimalDto animalDto = _mapper.Map<AnimalDto>(animal);
        return animalDto;
    }

    public async Task<AnimalDto> CreateAnimalAsync(AnimalForCreationDto? animal)
    {
        Animal? animalEntity = _mapper.Map<Animal>(animal);
        _backendManager.Animal.CreateAnimal(animalEntity);
        await _backendManager.SaveAsync();
        AnimalDto? animalToReturn = _mapper.Map<AnimalDto>(animalEntity);
        return animalToReturn;
    }

    public async Task DeleteAnimalAsync(int animalId, bool trackChanges)
    {
        Animal animal = await GetAnimalAndCheckIfItExists(animalId, trackChanges);
        _backendManager.Animal.DeleteAnimal(animal);
        await _backendManager.SaveAsync();
    }

    public async Task UpdateAnimalAsync(int animalId, AnimalForUpdateDto animalForUpdate, bool trackChanges)
    {
        Animal animalEntity = await GetAnimalAndCheckIfItExists(animalId, trackChanges);
        _mapper.Map(animalForUpdate, animalEntity);
        await _backendManager.SaveAsync();
    }
}