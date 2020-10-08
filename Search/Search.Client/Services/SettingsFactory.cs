using Microsoft.Extensions.Configuration;
using Nest;
using Search.Client.Options;
using System;

namespace Search.Client.Services
{
    public static class SettingsFactory
    {
        private static readonly IConfiguration _configuration;
        
        static SettingsFactory()
        {
            var builder = new ConfigurationBuilder();

            _configuration = builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                                    .Build();
        }

        public static ConnectionSettings CreateFrom<T>(ConnectionOptions options)
            where T : class
        {
            var connectionSection = _configuration.GetSection("connection");
            var host = options.Host ?? connectionSection["defaultHost"];
            var index = options.Index ?? connectionSection["defaultIndex"];

            var indexUri = new Uri(host);
            var settings = new ConnectionSettings(indexUri)
                .DefaultIndex(index)
                .DefaultMappingFor<T>(m => m
                    .IndexName(index)
                );

            return settings;
        }

    }
}
