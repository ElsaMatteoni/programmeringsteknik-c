using Nest;
using Search.Common.Models;
using System;

namespace Search.Client.Services
{
    public class RecipeClient : SearchClient
    {
        public RecipeClient(ElasticClient elasticClient) : base(elasticClient)
        {
            EnsureDefaultIndex(elasticClient);
        }

        public WriteResponseBase Index(RecipeDocument document)
        {
            return Index<RecipeDocument>(document);
        }

        public virtual ISearchResponse<RecipeDocument> Search(ISearchRequest<RecipeDocument> request)
        {
            return Search<RecipeDocument>(request);
        }

        public virtual ISearchResponse<RecipeDocument> Search(Func<SearchDescriptor<RecipeDocument>, ISearchRequest> selector = null)
        {
            return Search<RecipeDocument>(selector);
        }

        public virtual CountResponse Count(ICountRequest<RecipeDocument> request)
        {
            return Count<RecipeDocument>(request);
        }

        public virtual CountResponse Count(Func<CountDescriptor<RecipeDocument>, ICountRequest> selector = null)
        {
            return Count<RecipeDocument>(selector);
        }

        private void EnsureDefaultIndex(ElasticClient elasticClient)
        {
            var settings = elasticClient.ConnectionSettings;

            var indexExistResponse = elasticClient.Indices.Exists(settings.DefaultIndex);
            if (indexExistResponse.Exists)
                return;

            elasticClient.Indices.Create(settings.DefaultIndex,
                                         creationDescriptor => creationDescriptor.Map<RecipeDocument>(
                                             typeMapDescriptor => typeMapDescriptor.AutoMap<RecipeDocument>()));

        }
    }
}
