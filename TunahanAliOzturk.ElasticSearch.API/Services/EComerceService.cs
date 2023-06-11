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

        public async Task<ImmutableList<ECommerce>> TermLevelQueryAsync(string customerFirstName)
        {
            return await _repository.TermLevelQueryAsync(customerFirstName);    
        }
        public async Task<ImmutableList<ECommerce>> PrefixLevelQueryAsync(string customerFirstName)
        {
            return await _repository.PrefixLevelQueryAsync(customerFirstName);
        }
        public async Task<ImmutableList<ECommerce>> RangeLevelQueryAsync(double minPrice,double maxPrice)
        {
            return await _repository.RangeLevelQueryAsync(minPrice,maxPrice);
        }
        public async Task<ImmutableList<ECommerce>> RangeLevelQueryForDateAsync(DateTime minDate, DateTime maxDate)
        {
            return await _repository.RangeLevelQueryForDateAsync(minDate, maxDate);
        }
    }
}
