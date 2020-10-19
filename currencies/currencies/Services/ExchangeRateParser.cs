using currencies.Models;
using System;

namespace currencies.Services
{
    public class ExchangeRateParser
    {
        public static ExchangeRate Parse(string input)
        {
            var data = input.Split(";");

            DateTime date = DateTime.Parse(data[0]);
            Money conversion = MoneyParser.Parse(data[1]);
            decimal rate = MoneyParser.ParseAmount(data[2]);

            return new ExchangeRate
            {
                ConversionRate = rate / conversion.Amount,
                Currency = conversion.Currency,
                Date = date
            };
        }
    }
}
