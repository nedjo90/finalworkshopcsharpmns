namespace backend;

public class MultipleException : Exception
{
    public List<object>? ListOfErrors { get; set; }
    public Dictionary<object,object>? DictionaryOfErrors { get; set; }
    public MultipleException(string message, Dictionary<object, object> dictionaryOfErrors) : base(message)
    {
        DictionaryOfErrors = dictionaryOfErrors;
    }
    
    public MultipleException(string message, List<object> listOfErrors) : base(message)
    {
        ListOfErrors = listOfErrors;
    }

    public MultipleException(string message) : base(message)
    {
    }
}