using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Search.Common.Models.Dto;
using System;
using System.IO;

namespace Search.Common.Services
{
    public static class RecipeScraper
    {
        private const string _dataElementId = "__NEXT_DATA__";
        private const string _recipeJsonPath = "props.pageProps.structuredData[?(@['\x40type']=='Recipe')]";
        private const string _categoriesJsonPath = "props.pageProps.item.categories";

        private static readonly JsonSerializer _serializer;

        static RecipeScraper()
        {
            _serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public static RecipeDto GetRecipeData(Uri uri)
        {
            var document = GetDocument(uri);
            var dataElement = document.GetElementbyId(_dataElementId);
            if (dataElement == null)
                throw new InvalidDataException("No data found on requested page");

            var pageData = JsonConvert.DeserializeObject<JObject>(dataElement.InnerHtml);
            var structuredData = pageData.SelectToken(_recipeJsonPath) as JObject;
            if (structuredData == null)
                throw new InvalidDataException("No recipe data found on requested page");

            var recipeDto = structuredData.ToObject<RecipeDto>(_serializer);
            
            var categoryData = pageData.SelectToken(_categoriesJsonPath) as JArray;
            if (categoryData != null)
            {
                recipeDto.Categories = categoryData.ToObject<CategoryDto[]>(_serializer);
            }

            return recipeDto;
        }

        private static HtmlDocument GetDocument(Uri uri)
        {
            var web = new HtmlWeb();
            return web.Load(uri.OriginalString);
        }
    }
}
