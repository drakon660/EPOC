using FullContact.API.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.API
{
    [Obsolete]
    public class FullContactClient
    {
        private const string enrichApi = "https://api.fullcontact.com/v3/";
        private readonly string _clientId;
        public FullContactClient(string clientId)
        {
            _clientId = clientId;
        }

        public async Task<FullContactResponse> Enrichment(PersonSummaryObject personSummary)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(enrichApi);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _clientId);

                var json = SerializeObject(personSummary);

                var response = await client.PostAsync("person.enrich", new StringContent(json, Encoding.UTF8, "application/json"));

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
        }
        protected virtual string SerializeObject<T>(T t)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var json = JsonConvert.SerializeObject(t, serializerSettings);
            return json;
        }
    }

    public class EnrichmentRequestMessage
    {
        public string Twitter { get; set; }

        public string FaceBook { get; set; }

        public string LinkedIn { get; set; }
    }
}
