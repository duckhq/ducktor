using Newtonsoft.Json;
using System;

namespace Ducktor.Models
{
    public sealed class Build
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("project")]
        public string Project { get; set; }
        [JsonProperty("definition")]
        public string Definition { get; set; }
        [JsonProperty("branch")]
        public string Branch { get; set; }
        [JsonProperty("status")]
        public BuildStatus Status { get; set; }
        [JsonProperty("started")]
        public DateTime Started { get; set; }
        [JsonProperty("finished")]
        public DateTime? Finished { get; set; }
    }
}
