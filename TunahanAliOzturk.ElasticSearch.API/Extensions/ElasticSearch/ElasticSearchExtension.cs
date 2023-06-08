using Elasticsearch.Net;
using Nest;

namespace TunahanAliOzturk.ElasticSearch.API.Extensions.ElasticSearch
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticService(this IServiceCollection services,IConfiguration configuration)
        {
            var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("ElasticSearch")["Url"]!));

            var settings = new ConnectionSettings(pool);

            settings.BasicAuthentication(username: configuration.GetSection("ElasticSearch")["Username"]!, password: configuration.GetSection("ElasticSearch")["Password"]!);

            var client = new ElasticClient(settings);

            services.AddSingleton(client);
        }
    }
}
