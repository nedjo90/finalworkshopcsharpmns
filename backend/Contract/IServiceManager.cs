namespace backend.Contract;

public interface IServiceManager
{
    IRaceService RaceService { get; }
    IAnimalService AnimalService { get; }
    IAuthenticationService AuthenticationService { get; }
}