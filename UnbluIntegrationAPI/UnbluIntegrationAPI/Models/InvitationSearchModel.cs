using Newtonsoft.Json;

namespace UnbluIntegrationAPI.Models
{
    public class Operator
    {
       public string value { get; set; }
    }

    public class OrderBy
    {
        public string field { get; set; }
        public string order { get; set; }
    }

    public class InvitationSearchModel
    {
        public List<SearchFilter> searchFilters { get; set; }
        public List<OrderBy> orderBy { get; set; }
    }

    public class SearchFilter
    {
        public string field { get; set; }
        public Operator @operator { get; set; }
    }

}
