using System.Collections.Generic;

namespace RecipeScraper.Models
{
    class RecipeDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<string> RecipeIngredient { get; set; }
        public List<InstructionDto> RecipeInstructions { get; set; }
    }
}
