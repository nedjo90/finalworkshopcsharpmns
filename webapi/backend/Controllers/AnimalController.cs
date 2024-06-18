using backend.Contract;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;


[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    
    private readonly IServiceManager _serviceManager;

    public AnimalController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("{id:int}", Name = "AnimalById")]
    public async Task<IActionResult> GetAnimal(int id)
    {
            AnimalDto animal = await _serviceManager.AnimalService.GetAnimalAsync(id, trackChanges: false);
            return Ok(animal);
    }
    
    [HttpGet(Name = "GetAnimals")]
    public async Task<IActionResult> GetAnimals()
    {
        IEnumerable<AnimalDto> animals = 
            await _serviceManager.AnimalService.GetAllAnimalAsync(trackChanges: false);

        return Ok(animals);
    }
    
    [HttpPost(Name = "CreateAnimal")]
        public async Task<IActionResult> CreateAnimal([FromBody]AnimalForCreationDto? animal)
    {
            AnimalDto createdAnimal = await _serviceManager.AnimalService.CreateAnimalAsync(animal);
        
        return CreatedAtRoute("AnimalById", new { id = createdAnimal.Id }, createdAnimal);
    }
        
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        await _serviceManager.AnimalService.DeleteAnimalAsync(id, trackChanges: false);
        return NoContent();
    }
    
    public async Task<IActionResult> UpdateAnimal(int id, [FromBody] AnimalForUpdateDto? animal)
    {
        await _serviceManager.AnimalService.UpdateAnimalAsync(id, animal!, trackChanges: true);
        return NoContent();
    }
    
    [HttpOptions]
    public IActionResult GetAnimalOptions()
    {
        Response.Headers.Allow = "GET, POST, PUT, DELETE, OPTIONS";
        return Ok();
    }
}