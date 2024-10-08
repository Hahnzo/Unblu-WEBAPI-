﻿using Newtonsoft.Json;

namespace UnbluIntegrationAPI.Models
{
    public class CreateConversationModel
    {
        [JsonProperty("$_type")]
        public string Type { get; set; } = "ConversationCreationModel";
        public string Topic { get; set; }
        public Recipient Recipient { get; set; }
        public List<Participant> Participants { get; set; }
        public string InitialEngagementType { get; set; }
        public string ConversationVisibility { get; set; }
        public string Locale { get; set; }
        public string VisitorData { get; set; }
        public string? ConversationTemplateId { get; set; }
        public bool InheritConfigurationAndTexts { get; set; }

        public string? SourceId { get; set; }
        public string? SourceUrl { get; set; }
        public string InitialEngagementUrl { get; set; }
        public Metadata Metadata { get; set; }
    }

    public class Recipient
    {
        [JsonProperty("$_type")]
        public string Type { get; set; } = "ConversationCreationRecipientData";
        public string Id { get; set; }
    }

    public class Participant
    {
        [JsonProperty("$_type")]
        public string Type { get; set; } = "ConversationCreationParticipantData"; 

        public string PersonId { get; set; }
        public bool Hidden { get; set; }
        public bool ConversationStarred { get; set; }
        public string ParticipationType { get; set; }
    }
}
