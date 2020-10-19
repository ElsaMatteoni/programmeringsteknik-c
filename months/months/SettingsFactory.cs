using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace months
{
    public class SettingsFactory
    {
        private static IConfiguration _configuration;

        static SettingsFactory()
        {
            var builder = new ConfigurationBuilder();

            _configuration = builder.AddJsonFile("appsettings.json", true, false)
                                    .Build();
        }

        public static CultureInfo GetCulture()
        {
            string cultureSetting = _configuration["culture"] ?? "sv-SE";

            return new CultureInfo(cultureSetting);
        }
    }
}
