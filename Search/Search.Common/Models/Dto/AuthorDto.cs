using Newtonsoft.Json;

namespace Search.Common.Models.Dto
{
    public class AuthorDto
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
