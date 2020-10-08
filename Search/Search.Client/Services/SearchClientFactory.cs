using Nest;
using Search.Client.Options;
using System;

namespace Search.Client.Services
{
    public static class SearchClientFactory
    {
        public static RecipeClient CreateClient(ConnectionOptions options)
        {
            return new RecipeClient(CreateElasticClient<RecipeClient>(options));
        }

        private static ElasticClient CreateElasticClient<T>(ConnectionOptions options)
            where T : class
        {
            var settings = SettingsFactory.CreateFrom<T>(options);
            return new ElasticClient(settings);
        }
    }
}
