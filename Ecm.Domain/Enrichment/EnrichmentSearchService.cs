using Bing.Entity.Search.API;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.Domain.Enrichment
{
    public class EnrichmentSearchService : IEnrichmentSearchService
    {
        private readonly BingEntitySearchClient _client;
        private IFindEnityAndCountryInTextStrategy _findEnityAndCountryInTextStrategy;
        public EnrichmentSearchService(IFindEnityAndCountryInTextStrategy findEnityAndCountryInTextStrategy, BingEntitySearchClient client)
        {
            _findEnityAndCountryInTextStrategy = findEnityAndCountryInTextStrategy;
            _client = client;
        }
        public async Task<EnrichmentResult> FindBy(string text)
        {
            (string entity, string country) entityWithCountry = _findEnityAndCountryInTextStrategy.GetEntityAndCountryFrom(text);

            if (string.IsNullOrEmpty(entityWithCountry.country))
                return EnrichmentResult.CreateWithError("Country Not Found In Countries List");

            FullContactResponse result = await _client.Enrichment(entityWithCountry.country, entityWithCountry.entity);

            if (result.Status == FullContactResponseStatus.DataFound)
            {
                Value value = result.Enrichment.entities.value.FirstOrDefault();
                string info = value.description;
                string name = value.name;
                string website = value.url;

                bool isCompany = _findEnityAndCountryInTextStrategy.IsCompany(value.entityPresentationInfo.entityTypeHints);

                return EnrichmentResult.CreateNew(Enrichment.CreateNew(value.name, "", value.image.thumbnailUrl, value.description, value.url, isCompany));
            }
            else if (result.Status == FullContactResponseStatus.DataNotFound)
            {
                return EnrichmentResult.CreateNew(null);
            }
            else
            {
                return EnrichmentResult.CreateWithError(result.ErrorMessage);
            }
        }

        protected virtual (string, string) GetEntityAndCountryFrom(string text)
        {
            return _findEnityAndCountryInTextStrategy.GetEntityAndCountryFrom(text);
        }

        protected virtual bool IsCompany(List<string> hints)
        {
            return !hints.Contains("Person");
        } 
    }
}
