using System;
using System.Collections.Generic;
using System.Text;

namespace Bing.Entity.Search.API
{
    public class QueryContext
    {
        public string originalQuery { get; set; }
    }

    public class License
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class ContractualRule
    {
        public string _type { get; set; }
        public string targetPropertyName { get; set; }
        public bool mustBeCloseToContent { get; set; }
        public License license { get; set; }
        public string licenseNotice { get; set; }
        public string text { get; set; }
        public string url { get; set; }
    }

    public class Provider
    {
        public string _type { get; set; }
        public string url { get; set; }
    }

    public class Image
    {
        public string name { get; set; }
        public string thumbnailUrl { get; set; }
        public List<Provider> provider { get; set; }
        public string hostPageUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int sourceWidth { get; set; }
        public int sourceHeight { get; set; }
    }

    public class EntityPresentationInfo
    {
        public string entityScenario { get; set; }
        public List<string> entityTypeHints { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public List<ContractualRule> contractualRules { get; set; }
        public string webSearchUrl { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Image image { get; set; }
        public string description { get; set; }
        public EntityPresentationInfo entityPresentationInfo { get; set; }
        public string bingId { get; set; }
    }

    public class Entities
    {
        public List<Value> value { get; set; }
    }

    public class Value2
    {
        public string id { get; set; }
    }

    public class Item
    {
        public string answerType { get; set; }
        public int resultIndex { get; set; }
        public Value2 value { get; set; }
    }

    public class Sidebar
    {
        public List<Item> items { get; set; }
    }

    public class RankingResponse
    {
        public Sidebar sidebar { get; set; }
    }

    public class RawEnrichment
    {
        public string _type { get; set; }
        public QueryContext queryContext { get; set; }
        public Entities entities { get; set; }
        public RankingResponse rankingResponse { get; set; }
    }
}
