using System;

namespace leapyearcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Räkna ut hur många skottår som passerat mellan två inmatade värden.
            // DateTime.IsLeapYear(year) är en metod man kan använda.

            int firstYear = int.Parse(args[0]);
            int secondYear = int.Parse(args[1]);

            int maxYear = Math.Max(firstYear, secondYear);
            int minYear = Math.Min(firstYear, secondYear);

            int leapYearCount = 0;

            for (int year = minYear; year <= maxYear; year++)
            {
                bool isLeapYear = DateTime.IsLeapYear(year);

                if (isLeapYear)
                {
                    leapYearCount++;
                }
            }

            Console.WriteLine($"Encountered {leapYearCount} leap years from {minYear} to {maxYear}.");
        }
    }
}
