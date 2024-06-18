namespace backend.Exceptions;

public class BadRequestMultipleException : MultipleException
{
    public BadRequestMultipleException(string message, Dictionary<object, object> dictionaryOfErrors) : base(message, dictionaryOfErrors)
    {
    }
    
    public BadRequestMultipleException(string message, List<object> listOfErrors) : base(message, listOfErrors)
    {
    }
}