using System.Text.Json.Serialization;

namespace TunahanAliOzturk.ElasticSearch.API.Models.SampleDataModels
{
    public class ECommerce
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("customer_first_name")]
        public string CustomerFirstName { get; set; } = null!;

        [JsonPropertyName("customer_last_name")]
        public string CustomerLastName { get; set; } = null!;

        [JsonPropertyName("customer_full_name")]
        public string CustomerFullName { get; set; } = null!;

        [JsonPropertyName("taxful_total_price")]
        public double TaxfulTotalPrice { get; set; }

        [JsonPropertyName("category")]
        public string[] Category { get; set; } = null!;

        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("order_date")]
        public DateTime OrderDate { get; set; }
        [JsonPropertyName("products")]

        public EProduct[] Products { get; set; } = null!;
    }
}
