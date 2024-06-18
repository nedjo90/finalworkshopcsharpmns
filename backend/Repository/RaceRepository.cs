using backend.Contract;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Repository;

public class RaceRepository : BackendBase<Race>, IRaceRepository
{
    
    public RaceRepository(BackendContext repositoryContext) : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<Race>> GetAllRacesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Race?> GetRaceAsync(int raceId, bool trackChanges)
    {
        return await FindByCondition(c => c.Id.Equals(raceId), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateRace(Race race)
    {
        Create(race);
    }

    public void DeleteRace(Race race)
    {
        Delete(race);
    }
}