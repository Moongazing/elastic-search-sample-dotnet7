using System.Collections.Immutable;
using System.Net;
using TunahanAliOzturk.ElasticSearch.API.DTOs;
using TunahanAliOzturk.ElasticSearch.API.Models.SampleDataModels;
using TunahanAliOzturk.ElasticSearch.API.Repositories;

namespace TunahanAliOzturk.ElasticSearch.API.Services
{
    public class EComerceService
    {
        private readonly ECommerceRepossitory _repository;

        public EComerceService(ECommerceRepossitory repository)
        {
            _repository = repository;
        }

        public async Task<ImmutableList<ECommerce>> TermLevelQuery(string customerFirstName)
        {
            return await _repository.TermLevelQuery(customerFirstName);

            
        }
    }
}
