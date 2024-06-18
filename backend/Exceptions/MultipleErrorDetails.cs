using Newtonsoft.Json;

namespace backend;


public class MultipleErrorDetails
{
    public int  StatusCode { get; set; }
    public string Message { get; set; }

    [JsonProperty("Errors")]
    public List<object>? ListOfErrors { get; set; } = null;

    [System.Text.Json.Serialization.JsonIgnore] 
    public Dictionary<object, object>? DictionaryOfErrors { get; set; } = null;
    
    [JsonProperty("Details")]
    private List<ErrorItem>? SerializedDetails
    {
        get
        {
            return DictionaryOfErrors?.Select(kv => new ErrorItem { Source = kv.Key, Error = kv.Value }).ToList();
        }
        set
        {
            DictionaryOfErrors = value?.ToDictionary(item => item.Source, item => item.Error);
        }
    }

    public bool ShouldSerializeListOfErrors()
    {
        return ListOfErrors != null;
    }
    public bool ShouldSerializeSerializedDetails()
    {
        return DictionaryOfErrors != null;
    }
    
    private class ErrorItem
    {
        public object Source { get; set; }
        public object Error { get; set; }
    }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}