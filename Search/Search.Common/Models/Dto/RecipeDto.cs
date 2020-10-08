namespace Search.Common.Models.Dto
{
    public class RecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public AuthorDto Author { get; set; }
        public string[] RecipeIngredient { get; set; }
        public RecipeInstructionDto[] RecipeInstructions { get; set; }
        public AggregateRatingDto AggregateRating { get; set; }
        public CategoryDto[] Categories { get; set; }
        public string TotalTime { get; set; }
    }
}
