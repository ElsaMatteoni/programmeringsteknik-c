using currencies.Models;
using currencies.Services;
using System;

namespace currencies
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // 2. Skapa sedan ett uppslagsverk med valutanamn och skriv ut namnen på valutorna konverteringen sker emellan.
            // (Valutor lagras på RegionInfo, en egenskap på CultureInfo) 

            // 3. Lägg till ett ytterligare val för valuta att konvertera till (förutom SEK).  
            MoneyConverter moneyConverter = new MoneyConverter(".\\Resources\\Riksbanken_2020-10-13.csv", "SEK");

            Console.WriteLine("Skriv in önskad växlings-valuta och belopp (tex. 100 USD)");
            string input = Console.ReadLine();

            Money enteredMoney = MoneyParser.Parse(input);
            Money convertedMoney = moneyConverter.ConvertToTargetCurrency(enteredMoney);

            Console.WriteLine($"Dina {enteredMoney} ({GetcurrencyName(enteredMoney)}) blir {convertedMoney} ({GetcurrencyName(convertedMoney)})");
        }

        public static string GetcurrencyName(Money money)
        {
            return CurrencyLookup.GetCurrencyName(money.Currency);
        }
    }
    
}
