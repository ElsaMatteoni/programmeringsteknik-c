using currencies.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace currencies.Services
{
    public class MoneyConverter
    {
        private readonly string _targetCurrency;
        private IDictionary<string, ExchangeRate> _exchangeRates;

        public MoneyConverter(string filePath, string targetCurrency)
        {
            _exchangeRates = new Dictionary<string, ExchangeRate>(StringComparer.OrdinalIgnoreCase);
            _targetCurrency = targetCurrency;

            ReadFile(filePath);
        }

        public Money ConvertToTargetCurrency(Money money)
        {
            ExchangeRate rate = _exchangeRates[money.Currency];
            decimal convertedAmount = money.Amount * rate.ConversionRate;
            return new Money(convertedAmount, _targetCurrency);
        }
        private void ReadFile(string filePath)
        {
            
            using (Stream stream = File.OpenRead(filePath))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            ExchangeRate rate = ExcangeRateParser.Parse(line);
                            _exchangeRates.Add(rate.Currency, rate);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }

                }
            }
        }
    }
}
