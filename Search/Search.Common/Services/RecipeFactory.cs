using Search.Common.Models;
using Search.Common.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Search.Common.Services
{
    public static class RecipeFactory
    {
        public static RecipeDocument CreateFrom(Uri uri)
        {
            RecipeDto data = RecipeScraper.GetRecipeData(uri);

            return new RecipeDocument
            {
                Id = GenerateGuidFromUrl(uri),
                Url = uri,
                Name = data.Name,
                Author = data.Author?.Name,
                Description = data.Description,
                Image = data.Image,
                Rating = data.AggregateRating?.RatingValue ?? 0,
                TimeToCook = GetTime(data.TotalTime),
                Ingredients = MapList(data.RecipeIngredient),
                Steps = MapList(data.RecipeInstructions, x => x.Text),
                Categories = MapList(data.Categories, x => x.Name)
            };
        }

        private static Guid GenerateGuidFromUrl(Uri uri)
        {
            // Denna behöver normaliseras, bookmarks, query-parametrar osv behöver tas bort.
            string url = uri.GetLeftPart(UriPartial.Path).TrimEnd('/');

            byte[] bytes = Encoding.UTF8.GetBytes(url);
            MD5 hasher = MD5.Create();
            byte[] hash = hasher.ComputeHash(bytes);

            return new Guid(hash);
        }

        private static TimeSpan? GetTime(string formattedTime)
        {
            try
            {
                return XmlConvert.ToTimeSpan(formattedTime);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static List<T> MapList<T>(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return new List<T>(0);

            return new List<T>(enumerable);
        }

        private static List<T> MapList<T, U>(IEnumerable<U> enumerable, Func<U, T> projection)
        {
            if (enumerable == null)
                return new List<T>(0);

            return new List<T>(enumerable.Select(projection));
        }
    }
}
