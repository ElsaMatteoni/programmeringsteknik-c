using Newtonsoft.Json;

namespace Search.Common.Models.Dto
{
    public class RecipeInstructionDto
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public string Text { get; set; }
    }
}
