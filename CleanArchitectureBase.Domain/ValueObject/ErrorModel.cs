

using CleanArchitectureBase.Domain.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleanArchitectureBase.Domain.ValueObject
{
    public class ErrorModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ECode ErrorCode { get; set; }

        public string Message { get; set; }
    }
}
