using backend.Models;

namespace backend.Contract;

public interface IRaceRepository
{
    Task<IEnumerable<Race>> GetAllRacesAsync(bool trackChanges);
    Task<Race?> GetRaceAsync(int raceId, bool trackChanges);
    void CreateRace(Race race);
    void DeleteRace(Race race);
}