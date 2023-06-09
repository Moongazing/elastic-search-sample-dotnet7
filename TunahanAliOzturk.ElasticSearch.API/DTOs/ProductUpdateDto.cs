using TunahanAliOzturk.ElasticSearch.API.Models;

namespace TunahanAliOzturk.ElasticSearch.API.DTOs
{
    public record ProductUpdateDto(string Id,string Name, decimal Price, int Stock, ProductFeatureDto Feature)
    {
       
    }
}
