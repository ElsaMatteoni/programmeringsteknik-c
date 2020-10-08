using System;
using System.Collections.Generic;
using System.Linq;

namespace vowelapp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv en konsolapplikation som tar bort vokaler (konstigt va?) från en inmatad sträng.
            // Applikationen skall både presentera den resulterande strängen och antalet vokaler som togs bort.
            Console.Write("Skriv något: ");
            string input = Console.ReadLine();
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'ö' };
            int removedVowels = 0;

            var output = new List<char>();
            

            for (int i = 0; i < input.Length; i++)
            {
                var currentCharacter = input[i];
                var normalizedCharacter = char.ToLower(currentCharacter);
                if (vowels.Contains(normalizedCharacter) == false)
                {
                    output.Add(currentCharacter);
                }
                else
                {
                    removedVowels++;
                }
            }
            var resultingString = new string(output.ToArray());
            Console.WriteLine($"Din inmatning utan vokaler: '{resultingString}'.\nProgrammet tog bort {removedVowels} vokaler.");
                
        }
    }
}
