using AutoMapper;
using backend.Contract;
using backend.DTOs;
using backend.Exceptions;
using backend.Models;

namespace backend.Services;

internal sealed class RaceService : IRaceService
{
    private readonly IBackendManager _backendManager;
    private readonly IMapper _mapper;


    public RaceService(IBackendManager backendManager, IMapper mapper)
    {
        _backendManager = backendManager;
        _mapper = mapper;
    }

    
    public async Task<Race> GetRaceAndCheckIfItExists(int raceId, bool trackChanges)
    {
        Race? race = await _backendManager.Race.GetRaceAsync(raceId, trackChanges);
        if (race is null)
        {
            throw new RaceNotFoundException(raceId);
        }
        return race;
    }
    
    public async Task<IEnumerable<RaceDto>> GetAllRaceAsync(bool trackChanges)
    {
        IEnumerable<Race> races = await _backendManager.Race.GetAllRacesAsync(trackChanges);
        IEnumerable<RaceDto>? racesDto = _mapper.Map<IEnumerable<RaceDto>>(races);
        return racesDto;
    }

    public async Task<RaceDto> GetRaceAsync(int raceId, bool trackChanges)
    {
        Race race = await GetRaceAndCheckIfItExists(raceId, trackChanges);
        RaceDto? raceDto = _mapper.Map<RaceDto>(race);
        return raceDto;
    }

    public async Task<RaceDto> CreateRaceAsync(RaceForCreationDto? race)
    {
        Race? raceEntity = _mapper.Map<Race>(race);
        _backendManager.Race.CreateRace(raceEntity);
        await _backendManager.SaveAsync();
        RaceDto? raceToReturn = _mapper.Map<RaceDto>(raceEntity);
        return raceToReturn;
    }

    public async Task DeleteRaceAsync(int raceId, bool trackChanges)
    {
        Race race = await GetRaceAndCheckIfItExists(raceId, trackChanges);
        _backendManager.Race.DeleteRace(race);
        await _backendManager.SaveAsync();
    }

    public async Task UpdateRaceAsync(int raceId, RaceForUpdateDto raceForUpdate, bool trackChanges)
    {
        Race raceEntity = await GetRaceAndCheckIfItExists(raceId, trackChanges);
        _mapper.Map(raceForUpdate, raceEntity);
        await _backendManager.SaveAsync();
    }
}