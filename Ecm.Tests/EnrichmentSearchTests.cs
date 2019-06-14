using Bing.Entity.Search.API;
using Ecm.Domain.Enrichment;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Moq;

namespace Ecm.Tests
{
    public class EnrichmentSearchTests
    {
        private readonly IFindEnityAndCountryInTextStrategy _findEnityAndCountryInTextStrategy;
        public EnrichmentSearchTests()
        {
            _findEnityAndCountryInTextStrategy = new SimpleFindEnityAndCountryInTextStrategy();
        }

        [Theory]
        [InlineData(new object[] { new string[] {  "Organization" } })]
        [InlineData(new object[] { new string[] { "" } })]
        public void Check_If_Business(string[] hints)
        {
            Assert.True(_findEnityAndCountryInTextStrategy.IsCompany(hints.ToList()));
        }

        [Theory]
        [InlineData(new object[] { new string[] { "Person" } })]
        [InlineData(new object[] { new string[] { "Person", "" } })]
        public void Check_If_Invidual(string[] hints)
        {
            Assert.True(!_findEnityAndCountryInTextStrategy.IsCompany(hints.ToList()));
        }
        [Theory]
        [InlineData("Bill Gates united States", "Bill Gates", "United States")]
        [InlineData("Krzysztof Nitwinko France", "Krzysztof Nitwinko","France")]
        //[InlineData("France", "Krzysztof Nitwinko", "France")]
        public void Chech_If_Country_Supported_InSearch(string text, string expectedEntity, string expectedCountry)
        {
            //entity, country
            (string entity, string country) entityWithCountry = _findEnityAndCountryInTextStrategy.GetEntityAndCountryFrom(text);

            //Assert.Equal((expectedEntity, expectedCountry), entityWithCountry);
            entityWithCountry.entity.ToLower().Should().NotBeNullOrEmpty().And.Be(expectedEntity.ToLower());

            entityWithCountry.country.ToLower().Should().NotBeNullOrEmpty().And.Be(expectedCountry.ToLower());
        }
        [Theory]
        [InlineData("Bill Gates")]
        [InlineData("Bill")]
        [InlineData("B t")]
        public void Chech_If_Country_NotFound_InSearch(string text)
        {
            //entity, country
            (string entity, string country) entityWithCountry = _findEnityAndCountryInTextStrategy.GetEntityAndCountryFrom(text);

            //Assert.Equal((expectedEntity, expectedCountry), entityWithCountry);
            entityWithCountry.entity.Should().BeNull();

            entityWithCountry.country.Should().BeNull();
        }
    }
}
