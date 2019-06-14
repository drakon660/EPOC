using Bing.Entity.Search.API;
using Ecm.Core;
using Ecm.Domain.Enrichment;
using FullContact.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.Terminal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //FullContactClient client = new FullContactClient("IP4D8UX4MwmwDgEfkU9g4Yd84ywvbfBk");
            //var test = await client.Enrichment(null);

            //AuthorizationManager manger = new AuthorizationManager(new string[] { "drakon660@gmail.com" }, new string[] { "gmail.com" });

            //manger.IsUserOrDomainAuthorized("drakon660@gmail.com");

            //BingEntitySearchClient client = new BingEntitySearchClient("997703fa9d7a46b79ddf9291ac29a235");
            //await client.Enrichment("Bill Gates");
            //EnrichmentSearchService enrichmentSearchService = new EnrichmentSearchService(new BingEntitySearchClient(""));
            //await enrichmentSearchService.FindBy("Krzysztof Nitwinko Poland");

            //enrichmentSearchService.GetEntityAndCountryFrom("Bill Gates");
            //enrichmentSearchService.GetCountryFrom("Krzysztof Nitwinko Poland cos tam cos");

            //var JsonCountriesPath = Path.Combine("d:\\", "countries.json");
            //Dictionary<string, string> emptyDictionary = new Dictionary<string, string>();
            //string json = string.Empty;
            //using (StreamReader SourceReader = System.IO.File.OpenText(JsonCountriesPath))
            //{
            //    json = SourceReader.ReadToEnd();
            //}

            //var d = JsonConvert.DeserializeObject<List<RootObject>> (json);
            //StringBuilder builder = new StringBuilder();
            //builder.Append("List<string> emptyDictionary = new List<string>(){");
            //foreach (var t in d)
            //{
            //    builder.AppendFormat("\"{0}\",",t.name);
            //    builder.AppendLine();
            //}
            //builder.Append("}");
            //string value = builder.ToString();
        }
    }
    public class RootObject
    {
        public string name { get; set; }
        public string code { get; set; }
    }
}
