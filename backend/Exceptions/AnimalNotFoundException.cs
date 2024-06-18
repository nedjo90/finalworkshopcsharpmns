namespace backend.Exceptions;

public class AnimalNotFoundException : NotFoundException
{
    public AnimalNotFoundException(int id) : base($"The animal with id: {id} doesn't exist in the database.")
    {
    }
}