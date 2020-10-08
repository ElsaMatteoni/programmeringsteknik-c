using System;
using System.Collections.Generic;

namespace Search.Common.Models
{
    public class RecipeDocument
    {
        public Guid Id { get; set; }
        public Uri Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public List<string> Steps { get; set; }
        public List<string> Ingredients { get; set; }
        public double Rating { get; set; }
        public TimeSpan? TimeToCook { get; set; }
        public List<string> Categories { get; set; }
    }
}
