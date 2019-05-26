using Newtonsoft.Json;

namespace MathHelper.Api.Models
{
    public class EvaluateRequest
    {
        [JsonProperty("expression")]
        public string Expression { get; set; }

        [JsonProperty("functionality")]
        public string Functionality { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }
    }
}