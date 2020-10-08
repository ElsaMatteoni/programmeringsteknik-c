using Nest;
using System;

namespace Search.Client.Services
{
    public abstract class SearchClient
    {
        private readonly ElasticClient _elasticClient;
        
        public SearchClient(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        protected virtual WriteResponseBase Index<T>(T document)
            where T : class
        {
            var response = _elasticClient.CreateDocument(document);
            if (response.IsValid)
                return response;

            var id = new Id(document);
            
            return _elasticClient.Update(DocumentPath<T>.Id(id), d => d.Doc(document));
        }

        protected virtual ISearchResponse<T> Search<T>(ISearchRequest<T> request)
            where T : class
        {
            return _elasticClient.Search<T>(request);
        }

        protected virtual ISearchResponse<T> Search<T>(Func<SearchDescriptor<T>, ISearchRequest> selector = null)
            where T : class
        {
            return _elasticClient.Search(selector);
        }

        protected virtual CountResponse Count<T>(ICountRequest<T> request)
            where T : class
        {
            return _elasticClient.Count(request);
        }

        protected virtual CountResponse Count<T>(Func<CountDescriptor<T>, ICountRequest> selector = null)
            where T : class
        {
            return _elasticClient.Count(selector);
        }
    }
}
