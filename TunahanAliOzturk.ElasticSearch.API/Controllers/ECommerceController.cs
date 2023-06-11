using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<IActionResult> GetFirstName(string firstName)
        {
            var result = await _service.TermLevelQuery(firstName);

            return Ok(result);
        }
    }
}
