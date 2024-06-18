using backend.Contract;

namespace backend.Repository;

public class BackendManager : IBackendManager
{
    private readonly BackendContext _backendContext;
    private readonly Lazy<IRaceRepository> _raceRepository;
    private readonly Lazy<IAnimalRepository> _animalRepository;
    public IRaceRepository Race => _raceRepository.Value;
    public IAnimalRepository Animal => _animalRepository.Value;

    public BackendManager(BackendContext backendContext)
    {
        _backendContext = backendContext;
        _raceRepository = new Lazy<IRaceRepository>(() => new RaceRepository(backendContext));
        _animalRepository = new Lazy<IAnimalRepository>(() => new AnimalRepository(backendContext));
    }
    
    public async Task SaveAsync()
    {
        await _backendContext.SaveChangesAsync();
    }

}