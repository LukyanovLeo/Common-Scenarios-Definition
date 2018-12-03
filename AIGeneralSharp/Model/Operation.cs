using Newtonsoft.Json;
using System.Collections.Generic;

namespace AIGeneralSharp.Model
{
    public class Operation
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("pre")]
        public List<Params> Pre { get; set; }
        [JsonProperty("post")]
        public List<Params> Post { get; set; }
    }
}
