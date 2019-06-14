using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecm.Domain;
using Ecm.Domain.Enrichment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IEnrichmentSearchService _enrichmentSearchService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SearchController(IEnrichmentSearchService enrichmentSearchService, IHostingEnvironment hostingEnvironment)
        {
            _enrichmentSearchService = enrichmentSearchService;
            _hostingEnvironment = hostingEnvironment;
        }

        private Dictionary<string,string> ReadCountries()
        {
            var JsonCountriesPath = Path.Combine(_hostingEnvironment.WebRootPath, "countries.json");
            Dictionary<string, string> emptyDictionary = new Dictionary<string, string>();
            string json = string.Empty;
            using (StreamReader SourceReader = System.IO.File.OpenText(JsonCountriesPath))
            {
                json = SourceReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
       

        [HttpGet("")]
        [HttpGet("{text}")]
        //[Authorize]
        public async Task<IActionResult> Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return Ok(Result.Fail("Please fill entity name country input"));

            EnrichmentResult result = await _enrichmentSearchService.FindBy(text);

            return Ok(Result.Ok<EnrichmentResult>(result));
        }
    }
}