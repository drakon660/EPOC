using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain.Enrichment
{
    public interface IFindEnityAndCountryInTextStrategy
    {
        (string, string) GetEntityAndCountryFrom(string text);
        bool IsCompany(IReadOnlyList<string> hints);
    }
}
