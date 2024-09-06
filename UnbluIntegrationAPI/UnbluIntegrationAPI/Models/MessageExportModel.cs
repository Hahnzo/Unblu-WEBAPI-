using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnbluIntegrationAPI.Models
{
public class MessageExportModel
    {
        [JsonProperty("$_type")]
        public string Type { get; set; }

        [JsonProperty("searchFilters")]
        public List<SearchFilterQuery> SearchFilters { get; set; }

        [JsonProperty("orderBy")]
        public List<OrderByQuery> OrderBy { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }

    public class SearchFilterQuery
    {
        [JsonProperty("$_type")]
        public string Type { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("operator")]
        public OperatorQuery Operator { get; set; }
    }

    public class OperatorQuery
    {
        [JsonProperty("$_type")]
        public string Type { get; set; }

        [JsonProperty("type")]
        public string OperatorType { get; set; }

        [JsonProperty("minimum")]
        public long Minimum { get; set; }

        [JsonProperty("maximum")]
        public long Maximum { get; set; }
    }

    public class OrderByQuery
    {
        [JsonProperty("$_type")]
        public string Type { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }
    }

}
