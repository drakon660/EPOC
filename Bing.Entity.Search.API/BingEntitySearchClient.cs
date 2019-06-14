using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bing.Entity.Search.API
{
    public sealed class BingEntitySearchClient
    {
        private const string enrichApiUrl = "https://api.cognitive.microsoft.com";
        private const string entityApiUrl = "bing/v7.0/entities";
        private readonly HttpClient _httpClient;
        private readonly BingEntitySearchConfiguration _bingEntitySearchConfiguration;

        public BingEntitySearchClient(HttpClient httpClient, BingEntitySearchConfiguration bingEntitySearchConfiguration)
        {
            _httpClient = httpClient;
            _bingEntitySearchConfiguration = bingEntitySearchConfiguration;
        }

        public async Task<FullContactResponse> Enrichment(string country, string query)
        {
            _httpClient.BaseAddress = new Uri(enrichApiUrl);
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _bingEntitySearchConfiguration.ApiKey);

            string market = MarketByCountry(country.Trim().ToLower());

            if (string.IsNullOrEmpty(market))
            {
                return FullContactResponse.CountryNotSupported();
            }

            string marketQuery = $"?mkt={market}";

            string queryUri = entityApiUrl + marketQuery + "&q=" + System.Net.WebUtility.UrlEncode(query);

            var response = await _httpClient.GetAsync(queryUri);

            if (response.IsSuccessStatusCode)
            {
                var rawResponse = await response.Content.ReadAsStringAsync();
                RawEnrichment rawEnrichment = JsonConvert.DeserializeObject<RawEnrichment>(rawResponse);
                return FullContactResponse.CreateNew(rawEnrichment);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return FullContactResponse.NotFound();
            }
            else
            {
                return FullContactResponse.Error(response.ToString());
            }

        }

        private string MarketByCountry(string country)
        {
            Dictionary<string, string> countryMarketMap = new Dictionary<string, string>();
            countryMarketMap["germany"] = "de-de";
            countryMarketMap["australia"] = "en-au";
            countryMarketMap["canada"] = "en-ca";
            countryMarketMap["uk"] = "en-gb";
            countryMarketMap["england"] = "en-gb";
            countryMarketMap["united kingdom"] = "en-gb";
            countryMarketMap["usa"] = "en-us";
            countryMarketMap["united states"] = "en-us";
            countryMarketMap["mexico"] = "es-mx";
            countryMarketMap["spain"] = "es-es";
            countryMarketMap["india"] = "en-in";
            countryMarketMap["france"] = "fr-fr";
            countryMarketMap["brazil"] = "pt-br";

            if (countryMarketMap.ContainsKey(country))
            {
                return countryMarketMap[country];
            }

            return string.Empty;
        }
    }
}
