using System;
using System.Collections.Generic;
using System.Text;

namespace FullContact.API.Model
{
    public class RawEnrichment
    {
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Twitter { get; set; }
        public object LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Bio { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public int Founded { get; set; }
        public int Employees { get; set; }
        public string Locale { get; set; }
        public string Category { get; set; }
        public Details Details { get; set; }
    }

    public class Details
    {
        public List<Location> Locations { get; set; }
    }

    public class Location
    {
        public string Label { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string RegionCode { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Formatted { get; set; }
        public string AddressLine1 { get; set; }
    }
}
