using System.Text.Json.Serialization;

namespace TunahanAliOzturk.ElasticSearch.API.Models.SampleDataModels
{
    public class EProduct
    {
        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }
        [JsonPropertyName("product_name")]
        public string ProductName { get; set; } = null!;

    }
}
