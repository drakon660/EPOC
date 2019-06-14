using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.Domain.Enrichment
{
    public interface IEnrichmentSearchService
    {
        Task<EnrichmentResult> FindBy(string text);
    }
}
