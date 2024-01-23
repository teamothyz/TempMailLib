using Newtonsoft.Json;

namespace TempMailLib
{
    public class MessageCollectionResponse
    {
        [JsonProperty("mailbox")]
        public string? Email {  get; set; }
    
        [JsonProperty("messages")]
        public List<MessageResponse>? Messages { get; set; }
    }

    public class MessageResponse
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("subject")]
        public string? Subject { get; set; }

        [JsonProperty("bodyPreview")]
        public string? BodyPreview { get; set; }

        [JsonProperty("from")]
        public string? From { get; set; }

        [JsonProperty("receivedAt")]
        public long? ReceivedAt { get; set; }

        [JsonProperty("attachmentsCount")]
        public int? AttachmentsCount { get; set; }
    }
}
