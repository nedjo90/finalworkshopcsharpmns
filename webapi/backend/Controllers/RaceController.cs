using backend.Contract;
using backend.DTOs;
using backend.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/races")]
[ApiController]
[Authorize]
public class RaceController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public RaceController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("{id:int}", Name = "RaceById")]
    public async Task<IActionResult> GetRace(int id)
    {
        RaceDto race = await _serviceManager.RaceService.GetRaceAsync(id, trackChanges: false);
        return Ok(race);
    }
    
    [HttpGet(Name = "GetRaces")]
    public async Task<IActionResult> GetRaces()
    {
            IEnumerable<RaceDto> animals = 
            await _serviceManager.RaceService.GetAllRaceAsync(trackChanges: false);

            return Ok(animals);
    }
    
    
    [HttpPost(Name = "CreateRace")]
    public async Task<IActionResult> CreateRace([FromBody]RaceForCreationDto? race)
    {
        RaceDto createdRace = await _serviceManager.RaceService.CreateRaceAsync(race);
        
        return CreatedAtRoute("RaceById", new { id = createdRace.Id }, createdRace);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRace(int id)
    {
        await _serviceManager.RaceService.DeleteRaceAsync(id, trackChanges: false);
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateRace(int id, [FromBody] RaceForUpdateDto? race)
    {
        await _serviceManager.RaceService.UpdateRaceAsync(id, race!, trackChanges: true);
        return NoContent();
    }
    
    [HttpOptions]
    public IActionResult GetRacesOptions()
    {
        Response.Headers.Allow = "GET, POST, PUT, DELETE, OPTIONS";
        return Ok();
    }
}