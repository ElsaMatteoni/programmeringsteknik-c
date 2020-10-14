using System;
using System.Globalization;

namespace months
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv ett program som tar en emot inmatad siffra (1-12)
            // och konverterar siffran till ett månadsnamn på svenska
            // programmet skall kasta ett fel om den inmatade siffran är något annat än 1-12.
            Console.WriteLine("Skriv en nummer mellan 1-12:");
            int input = Convert.ToInt32(Console.ReadLine());
            var cultureSwe = "sv-SE";
            while (true)
                if (input < 0 || input < 13)
                {

                    DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                    string monthName = CultureInfo.CreateSpecificCulture(cultureSwe).DateTimeFormat.GetMonthName(input).ToString();
                    Console.WriteLine(monthName);
                    break;
                }
                else
                {
                    Console.WriteLine("Du har skrivit in fel siffra");
                    break;
                }


        }
    }
}
