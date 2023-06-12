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

            //type-cover
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


        public async Task<ImmutableList<ECommerce>> MatchAllLevelQueryAsync()
        {
            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                  .Size(100)
                                                                  .Query(q => q
                                                                  .MatchAll()));

            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;

            }).ToImmutableList();

        }

        public async Task<ImmutableList<ECommerce>> Pagination(int page, int pageSize)
        {

            var pageFrom = (page - 1) * pageSize;

            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                  .Size(pageSize)
                                                                  .From(pageFrom)
                                                                  .Query(q => q
                                                                  .MatchAll()));

            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;

            }).ToImmutableList();

        }
        public async Task<ImmutableList<ECommerce>> WilcardLevelQuery(string customerFullName)
        {
            ;

            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                  .Query(q => q
                                                                  .Wildcard(w => w
                                                                  .Field(f => f
                                                                  .CustomerFullName
                                                                  .Suffix("keyword"))
                                                                  .Wildcard(customerFullName))));

            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;

            }).ToImmutableList();

        }
        public async Task<ImmutableList<ECommerce>> FuzzyLevelQuery(string customerFirstName)
        {
            var result = await _client.SearchAsync<ECommerce>(s => s.Index(indexName)
                                                                  .Query(q => q
                                                                  .Fuzzy(fu => fu
                                                                  .Field(f => f
                                                                  .CustomerFirstName
                                                                  .Suffix("keyword"))
                                                                  .Value(customerFirstName)
                                                                  .Fuzziness(new Fuzziness(1))))
                                                                  .Sort(s => s
                                                                  .Field(fs => fs
                                                                  .TaxfulTotalPrice, (new FieldSort()
                                                                  {
                                                                      Order = SortOrder.Desc

                                                                  }))));

            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;
            }).ToImmutableList();
        }

        public async Task<ImmutableList<ECommerce>> MatchFullTextQuery(string categoryName)
        {
            var result = await _client.SearchAsync<ECommerce>(s => s.Query
                                                             (q => q.Match
                                                             (m => m.Field
                                                             (f => f.Category)
                                                             .Query(categoryName))));

            return result.Hits.Select(hit =>
            {
                hit.Source!.Id = hit.Id;
                return hit.Source;
            }).ToImmutableList();




        }

    }
}
