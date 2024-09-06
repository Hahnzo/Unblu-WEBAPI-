using Newtonsoft.Json;

namespace UnbluIntegrationAPI.Models
{
    public class Operator
    {
        [JsonProperty("$_type")]
        public string Type { get; set; } = "EqualsIdOperator";

        [JsonProperty("type")]
        public string ComparisonType { get; set; } = "EQUALS";
        public string value { get; set; }
    }

    public class OrderBy
    {
        [JsonProperty("$_type")]
        public string Type { get; set; } = "ConversationInvitationOrderBy";
        public string field { get; set; }
        public string order { get; set; }
    }

    public class InvitationSearchModel
    {
        [JsonProperty("$_type")]
        public string Type { get; set; } = "ConversationInvitationQuery";
        public List<SearchFilter> searchFilters { get; set; }
        public List<OrderBy> orderBy { get; set; }
    }

    public class SearchFilter
    {
        [JsonProperty("$_type")]
        public string Type { get; set; } = "TargetTypeConversationInvitationSearchFilter";

        public string field { get; set; }
        public Operator @operator { get; set; }
    }

}
