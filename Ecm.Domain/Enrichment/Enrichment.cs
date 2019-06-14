using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Enrichment
{
    public class EnrichmentResult
    {
        public string ErrorMessage { get; private set; }
        public EnrichmentResultStatus Status { get; private set; }
        public Enrichment Enrichment { get; private set; }
        private EnrichmentResult() { }

        protected EnrichmentResult(Enrichment enrichment)
        {
            Enrichment = enrichment;
            Status = enrichment != null ? EnrichmentResultStatus.Found : EnrichmentResultStatus.NotFound;
        }

        protected EnrichmentResult(string errorMessge)
        {
            ErrorMessage = errorMessge;
            Status = EnrichmentResultStatus.Error;
        }

        public static EnrichmentResult CreateNew(Enrichment enrichment) => new EnrichmentResult(enrichment);
       
        public static EnrichmentResult CreateWithError(string errorMessge) => new EnrichmentResult(errorMessge);
    }

    public enum EnrichmentResultStatus
    {
        NotFound,
        Found,
        Error
    }

    public class Enrichment
    {
        public string Name { get; protected set; }
        public string Location { get; protected set; }
        public string Logo { get; protected set; }
        public string Info { get; protected set; }
        public string Page { get; protected set; }
        public bool IsCompany { get; private set; }

        protected Enrichment(string fullName, string locations, string logo, string info, string page, bool isCompany)
        {
            Name = fullName;
            Location = locations;
            Logo = logo;
            Info = info;
            Page = page;
            IsCompany = isCompany;
        }

        public static Enrichment CreateNew(string fullName, string locations,string logo,string info,string page, bool isCompany) => 
            new Enrichment(fullName, locations, logo, info, page, isCompany);
    }
}
