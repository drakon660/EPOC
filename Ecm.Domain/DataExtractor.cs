using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ecm.Domain
{
    public static class DataExtractor
    {
        public static IEnumerable<string> ExtractEmails(string data)
        {
            IList<string> extractedEmails = new List<string>();

            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            //find items that matches with our pattern
            MatchCollection emailMatches = emailRegex.Matches(data);

            StringBuilder sb = new StringBuilder();

            foreach (Match emailMatch in emailMatches)
            {
                extractedEmails.Add(emailMatch.Value);
            }

            return extractedEmails;
        }
    }
}
