using System;
using System.Collections.Generic;
using System.Text;

namespace Bing.Entity.Search.API
{
    public class BingEntitySearchConfiguration
    {
        public readonly string ApiKey;

        public BingEntitySearchConfiguration(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("Api Key for Bing Enity Search not set");

           ApiKey = apiKey;
        }
    }
}
