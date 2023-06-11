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
            







    }
}
