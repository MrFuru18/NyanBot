using System.Dynamic;
using Newtonsoft.Json;

namespace NyanBot
{
    struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set;}
    }
}