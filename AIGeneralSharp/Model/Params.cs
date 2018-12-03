using Newtonsoft.Json;

namespace AIGeneralSharp.Model
{
    public class Params
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
} 
