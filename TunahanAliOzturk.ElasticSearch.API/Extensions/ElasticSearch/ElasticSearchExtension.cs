
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace TunahanAliOzturk.ElasticSearch.API.Extensions.ElasticSearch
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticService(this IServiceCollection services, IConfiguration configuration)
        {
            var userName = configuration.GetSection("ElasticSearch")["Username"]!;
            var password = configuration.GetSection("ElasticSearch")["Password"]!;

            var settings = new ElasticsearchClientSettings(new Uri(configuration.GetSection("ElasticSearch")["Url"]!)).Authentication(new BasicAuthentication(userName,password));

            var client = new ElasticsearchClient(settings);

            services.AddSingleton(client);
        }
    }
}
