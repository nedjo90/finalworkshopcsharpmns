using backend.DTOs;

namespace backend.Contract;

public interface IRaceService
{
    Task<IEnumerable<RaceDto>> GetAllRaceAsync(bool trackChanges);
    Task<RaceDto> GetRaceAsync(int raceId, bool trackChanges);
    Task<RaceDto> CreateRaceAsync(RaceForCreationDto? race);
    Task DeleteRaceAsync(int raceId, bool trackChanges);
    Task UpdateRaceAsync(int raceId, RaceForUpdateDto raceForUpdate, bool trackChanges);
}