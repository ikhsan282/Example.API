using System.Text.Json.Serialization;

namespace MyPhotos.API.Utilities
{
    public class ResponseModel
    {
        public int Code { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Data { get; set; }
    }
}