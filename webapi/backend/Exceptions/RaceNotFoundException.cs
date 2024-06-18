namespace backend.Exceptions;

public class RaceNotFoundException : NotFoundException
{
    public RaceNotFoundException(int id) : base($"The race with id: {id} doesn't exist in the database.")
    {
    }
}