using System;
using System.Globalization;

namespace tgif
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv en applikation som läser in ett datum via användarinmatning,
            // som sedan räknar ut hur många dagar det är till nästa fredag.
            //Console.WriteLine("Mata in ett datum (ÅÅÅÅ-MM-DD)");
            //DateTime inputDate = Convert.ToDateTime(Console.ReadLine());
            //int daysUntilFriday = 0;

            //while (inputDate.DayOfWeek != DayOfWeek.Friday)
            //{
            //    inputDate = inputDate.AddDays(1);
            //    daysUntilFriday++;
            //}
            //Console.WriteLine($"Det är {daysUntilFriday} dagar till fredag.");
            DateTime date;
            while (!GetDateFromUser(out date));
            int daysUntilFriday = 0;
            while (date.DayOfWeek != DayOfWeek.Friday)
            {
                date = date.AddDays(1);
                daysUntilFriday++;
            }
            Console.WriteLine($"Det är {daysUntilFriday} dagar till fredag.");
        }

        static bool GetDateFromUser(out DateTime date)
        {
            Console.WriteLine("Enter a date:");
            string input = Console.ReadLine();

            CultureInfo culture = new CultureInfo("sv-SE");

            return DateTime.TryParse(input, culture, DateTimeStyles.AssumeLocal, out date);
        }
    }
}
