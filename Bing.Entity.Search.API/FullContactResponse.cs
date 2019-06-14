using System;
using System.Collections.Generic;
using System.Text;

namespace Bing.Entity.Search.API
{
    public class FullContactResponse
    {
        public FullContactResponseStatus Status { get; protected set; }

        public RawEnrichment Enrichment { get; private set; }

        public string ErrorMessage { get; private set; }
    
        protected FullContactResponse()
        {
            Status = FullContactResponseStatus.DataNotFound;
        }
        protected FullContactResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Status = FullContactResponseStatus.Error;
        }
        protected FullContactResponse(RawEnrichment rawEnrichment, FullContactResponseStatus status)
        {
            Enrichment = rawEnrichment;
            Status = status;
        }

        public static FullContactResponse CreateNew(RawEnrichment rawEnrichment)
        {
            return new FullContactResponse(rawEnrichment, FullContactResponseStatus.DataFound);
        }

        public static FullContactResponse CountryNotSupported()
        {
            return new FullContactResponse("Country Not Supported");
        }

        public static FullContactResponse NotFound()
        {
            return new FullContactResponse();
        }
        public static FullContactResponse Error(string errorMessage)
        {
            return new FullContactResponse(errorMessage);
        }
    }

    public enum FullContactResponseStatus
    {
        DataNotFound,
        DataFound,
        Error,
        CountryNotSupported
    }
}
