using Elastic.Clients.Elasticsearch;
using System.Collections.Immutable;
using TunahanAliOzturk.ElasticSearch.API.Models.SampleDataModels;

namespace TunahanAliOzturk.ElasticSearch.API.Repositories
{
    public class ECommerceRepossitory
    {

        private readonly ElasticsearchClient _client;
        private const string indexName = "kibana_sample_data_ecommerce";

        public ECommerceRepossitory(ElasticsearchClient client)
        {
            _client = client;
        }

        public async Task<ImmutableList<ECommerce>> TermLevelQueryAsync(string customerFirstName)
        {
            // var result = await _client.SearchAsync<ECommerce>(x =>x.Index(indexName).Query(q => q.Term(t => t.Field("customer_first_name.keyword").Value(customerFirstName))));

            //type 
            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                    .Query(q => q
                                                                    .Term(t => t
                                                                    .CustomerFirstName.Suffix("keyword"), customerFirstName)));

            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;

            }).ToImmutableList();
        }
        public async Task<ImmutableList<ECommerce>> PrefixLevelQueryAsync(string customerFullName) //Like startswith
        {
            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                     .Query(q => q
                                                                     .Prefix(p => p
                                                                     .Field(f => f
                                                                     .CustomerFirstName.Suffix("keyword"))
                                                                     .Value(customerFullName))));
            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;

            }).ToImmutableList();
        }

        public async Task<ImmutableList<ECommerce>> RangeLevelQueryAsync(double minPrice, double maxPrice) //Like startswith
        {
            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                   .Query(q => q
                                                                   .Range(r => r
                                                                   .NumberRange(nr => nr
                                                                   .Field(f => f
                                                                   .TaxfulTotalPrice)
                                                                   .Gte(minPrice)
                                                                   .Lte(maxPrice)))));
            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;

            }).ToImmutableList();
        }
        public async Task<ImmutableList<ECommerce>> RangeLevelQueryForDateAsync(DateTime minDate, DateTime maxDate)
        {
            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                  .Query(q => q
                                                                  .Range(r => r
                                                                  .DateRange(dr => dr
                                                                  .Field(f => f
                                                                  .OrderDate)
                                                                  .Gte(minDate)
                                                                  .Lte(maxDate)))));
            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;

            }).ToImmutableList();

        }
        public async Task<ImmutableList<ECommerce>> RangeLevelQuerya(DateTime minDate, DateTime maxDate)
        {
            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                  .Query(q => q
                                                                  .Range(r => r
                                                                  .DateRange(dr => dr
                                                                  .Field(f => f
                                                                  .OrderDate)
                                                                  .Gte(minDate)
                                                                  .Lte(maxDate)))));
            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;

            }).ToImmutableList();

        }


    }
}
