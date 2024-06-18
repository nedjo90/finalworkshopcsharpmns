using AutoMapper;
using backend.Contract;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IRaceService> _raceService;
    private readonly Lazy<IAnimalService> _animalService;
    private readonly Lazy<IAuthenticationService> _authenticationService;
    public IRaceService RaceService => _raceService.Value;
    public IAnimalService AnimalService => _animalService.Value;
    public IAuthenticationService AuthenticationService =>
        _authenticationService.Value;


    public ServiceManager(
        IBackendManager backendManager, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _raceService = new Lazy<IRaceService>(() =>
            new RaceService(backendManager, mapper));
        _animalService = new Lazy<IAnimalService>(() =>
            new AnimalService(backendManager, mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService( mapper, userManager,
                configuration));
    }
}