using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace RecipeScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Klockan är 03:35, måste bara få detta att funka till imorgon.
            var list = new List<Recipe>();
            var addresses = new List<string>
            {
                "https://www.koket.se/smorstekt-torskrygg-med-pestoslungad-blomkal-och-sparris",
                "https://www.koket.se/vegoburgare-med-tryffelmajonnas",
                "https://www.koket.se/smakrik-o-lrisotto-med-vitlo-ksrostad-tomat-citronsparris-och-het-chorizo",
                "https://www.koket.se/smorbakad-spetskal-med-krispig-kyckling-och-graddskum"
            };

            foreach (var url in addresses)
            {
                var recipe = Scraper.GetRecipe(url);
                list.Add(recipe);
            }

            try
            {
                foreach (var recipe in list)
                {
                    Console.WriteLine($"Recept: {recipe.Name}");
                    Console.WriteLine("-------");
                    Console.WriteLine(recipe.Description.Trim());
                    Console.WriteLine("-------");
                    Console.WriteLine("Ingredienser:");

                    foreach (var ingredient in recipe.Ingredients)
                    {
                        if (ingredient.Amount == 0)
                            Console.WriteLine(ingredient.Name);
                        else
                            Console.WriteLine($"{ingredient.Amount} {ingredient.Unit} {ingredient.Name}");
                    }

                    Console.WriteLine("-------");
                    Console.WriteLine("Steg:");

                    var stepCount = 1;

                    foreach (var step in recipe.Steps)
                    {
                         Console.WriteLine($"{stepCount++}: {step.Text}");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }

    class Recipe
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
    }

    class Ingredient
    {
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
    }

    class Step
    {
        public string T1 { get; set; }
        public string Text { get; set; }
    }
}
