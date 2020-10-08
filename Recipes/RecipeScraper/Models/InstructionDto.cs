using Newtonsoft.Json;

namespace RecipeScraper.Models
{
    class InstructionDto
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public string Text { get; set; }
    }
}
