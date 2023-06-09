using Nest;
using System.Collections.Immutable;
using TunahanAliOzturk.ElasticSearch.API.DTOs;
using TunahanAliOzturk.ElasticSearch.API.Models;

namespace TunahanAliOzturk.ElasticSearch.API.Repositories
{
    public class ProductRepository
    {
        private readonly ElasticClient _client;
        private const string indexName = "products";
        public ProductRepository(ElasticClient client)
        {
            _client = client;
        }
        public async Task<Product?> SaveAsync(Product product)
        {
            product.CreateDate = DateTime.Now;

            var response = await _client.IndexAsync(product, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));

            if (!response.IsValid)
            {
                return null;
            }

            product.Id = response.Id;

            return product;
        }
        public async Task<ImmutableList<Product>> GetAllAsync()
        {
            var result = await _client.SearchAsync<Product>(s => s.Index(indexName).Query(q => q.MatchAll()));

            foreach (var hit in result.Hits)
            {
                hit.Source.Id = hit.Id;
            }

            return result.Documents.ToImmutableList();
        }
        public async Task<Product> GetByIdAsync(string id)
        {
            var response = await _client.GetAsync<Product>(id, x => x.Index(indexName));
            if (!response.IsValid)
            {
                return null;
            }

            response.Source.Id = response.Id;
            return response.Source;
        }
        public async Task<bool> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var response = await _client.UpdateAsync<Product,ProductUpdateDto>(productUpdateDto.Id,x=>x.Index(indexName).Doc(productUpdateDto));

            return response.IsValid;
        }
    }
}
