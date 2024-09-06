using Newtonsoft.Json;

namespace UnbluIntegrationAPI.Models
{
    public class Configuration
    {
        public string property1 { get; set; }
        public string property2 { get; set; }
    }

    public class Metadata
    {
        public string property1 { get; set; }
        public string property2 { get; set; }
    }

    public class CreateWithRandomPasswordModel
    {
        public string id { get; set; }
        public int creationTimestamp { get; set; }
        public int modificationTimestamp { get; set; }
        public int version { get; set; }
        public string accountId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string teamId { get; set; }
        public string authorizationRole { get; set; }
        public string displayName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool externallyManaged { get; set; }
        public Configuration configuration { get; set; }
        public Metadata metadata { get; set; }
    }


}
