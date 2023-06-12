using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System;
using TunahanAliOzturk.ElasticSearch.API.Models.SampleDataModels;
using TunahanAliOzturk.ElasticSearch.API.Services;

namespace TunahanAliOzturk.ElasticSearch.API.Controllers
{

    public class ECommerceController : BaseController
    {
        private readonly EComerceService _service;
        public ECommerceController(EComerceService service)
        {
            _service = service;
        }
        [HttpGet("TermLevelQuery")]
        public async Task<IActionResult> TermLevelQuery(string firstName)
        {
            var result = await _service.TermLevelQueryAsync(firstName);

            return Ok(result);
        }
        [HttpGet("PrefixLevelQuery")]
        public async Task<IActionResult> PrefixLevelQuery(string fullName)
        {
            var result = await _service.PrefixLevelQueryAsync(fullName);

            return Ok(result);
        }
        [HttpGet("RangeLevelQuery")]
        public async Task<IActionResult> RangeLevelQuery(double minPrice, double maxPrice)
        {
            var result = await _service.RangeLevelQueryAsync(minPrice, maxPrice);
            return Ok(result);
        }
        [HttpGet("RangeLevelQueryForDate")]
        public async Task<IActionResult> RangeLevelQueryForDate(DateTime minDate, DateTime maxDate)
        {
            var result = await _service.RangeLevelQueryForDateAsync(minDate, maxDate);
            return Ok(result);
        }
        [HttpGet("MatchAllLevelQuery")]
        public async Task<IActionResult> MatchAllLevelQuery()
        {
            var result = await _service.MatchAllLevelQueryAsync();
            return Ok(result);
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination(int page, int pageSize)
        {
            var result = await _service.Pagination(page, pageSize);
            return Ok(result);
        }
        [HttpGet("WildcardLevelQuery")]
        public async Task<IActionResult> WildcardLevelQuery(string customerFullName)
        {
            var result = await _service.WilcardLevelQuery(customerFullName);
            return Ok(result);
        }

        [HttpGet("FuzzyLevelQuery")]
        public async Task<IActionResult> FuzzyLevelQuery(string customerFirstName)
        {
            var result = await _service.FuzzyLevelQuery(customerFirstName);
            return Ok(result);
        }

        [HttpGet("MatchAllTextQuery")]
        public async Task<IActionResult> MatchAllTextQuery(string categoryName)
        {
            var result = await _service.MatchFullTextQuery(categoryName);
            return Ok(result);
        }







    }
}
