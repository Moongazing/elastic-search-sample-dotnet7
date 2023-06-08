using Nest;
using TunahanAliOzturk.ElasticSearch.API.Models;

namespace TunahanAliOzturk.ElasticSearch.API.Repositories
{
    public class ProductRepository
    {
        private readonly ElasticClient _client;
        public ProductRepository(ElasticClient client)
        {
            _client = client;   
        }
        public async Task<Product?> SaveAsync(Product product)
        {
            product.CreateDate = DateTime.Now;

            var response = await _client.IndexAsync(product,x=>x.Index("products"));

            if(!response.IsValid)
            {
                return null;
            }

            product.Id = response.Id;

            return product;
        }
    }
}
