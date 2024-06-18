namespace backend.Contract;

public interface IBackendManager
{
    IRaceRepository Race { get; }
    IAnimalRepository Animal { get; }
    Task SaveAsync();
}