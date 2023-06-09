using System.Collections.Immutable;
using System.Net;
using TunahanAliOzturk.ElasticSearch.API.DTOs;
using TunahanAliOzturk.ElasticSearch.API.Models;
using TunahanAliOzturk.ElasticSearch.API.Repositories;

namespace TunahanAliOzturk.ElasticSearch.API.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto<ProductDto>> SaveAsync(ProductCreateDto request)
        {

            var response = await _repository.SaveAsync(request.CreateProduct());

            if (response == null)
            {
                return ResponseDto<ProductDto>.Fail(new List<string> { "Something goes wrong." }, HttpStatusCode.InternalServerError);
            }

            return ResponseDto<ProductDto>.Success(response.CreateDto(), HttpStatusCode.Created);

        }
        public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            var productListDto = new List<ProductDto>();
            
            foreach (var item in products)
            {
                if (item.Feature is null)
                {
                    productListDto.Add(new ProductDto(item.Id,item.Name,item.Price,item.Stock, null));
                    continue;
                }
                productListDto.Add(new ProductDto(item.Id, item.Name, item.Price, item.Stock, new ProductFeatureDto(item.Feature.Width, item.Feature.Height, item.Feature.Color.ToString())));
            }

            return ResponseDto<List<ProductDto>>.Success(productListDto, HttpStatusCode.OK);
        }

        public async Task<ResponseDto<ProductDto>> GetByIdAsync(string id)
        {

            var hasProduct = await _repository.GetByIdAsync(id);
            if (hasProduct == null)
            {
                return ResponseDto<ProductDto>.Fail("Product not found.",HttpStatusCode.NotFound);
            }
            return ResponseDto<ProductDto>.Success(hasProduct.CreateDto(), HttpStatusCode.OK);

        }
        public async Task<ResponseDto<bool>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var isSuccess = await _repository.UpdateAsync(productUpdateDto);

            if (!isSuccess)
            {
                return ResponseDto<bool>.Fail("Something goes wrong.", HttpStatusCode.NotFound);
            }
            return ResponseDto<bool>.Success(true, HttpStatusCode.NoContent);
        }
        public async Task<ResponseDto<bool>> DeleteAsync(string id)
        {
            var isSuccess = await _repository.DeleteAsync(id);

            if (!isSuccess)
            {
                return ResponseDto<bool>.Fail("Something goes wrong.", HttpStatusCode.NotFound);
            }
            return ResponseDto<bool>.Success(true, HttpStatusCode.NoContent);
        }

    }
}
