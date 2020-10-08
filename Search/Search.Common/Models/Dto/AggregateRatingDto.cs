using Newtonsoft.Json;

namespace Search.Common.Models.Dto
{
    public class AggregateRatingDto
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public double RatingValue { get; set; }
        public double RatingCount { get; set; }
        public double BestRating { get; set; }
        public double WorstRating { get; set; }
    }
}
