﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TunahanAliOzturk.ElasticSearch.API.DTOs;
using TunahanAliOzturk.ElasticSearch.API.Services;

namespace TunahanAliOzturk.ElasticSearch.API.Controllers
{
    
    public class ProductsController : BaseController
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(ProductCreateDto request)
        {
            return CreateActionResult(await _service.SaveAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return CreateActionResult(await _service.GetByIdAsync(id));

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            return CreateActionResult(await _service.UpdateAsync(productUpdateDto));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return CreateActionResult(await _service.DeleteAsync(id));
        }
    }
}
