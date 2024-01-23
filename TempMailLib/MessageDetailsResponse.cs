using Newtonsoft.Json;

namespace TempMailLib
{
    public class MessageDetailsResponse
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("receivedAt")]
        public long? ReceivedAt { get; set; }

        [JsonProperty("user")]
        public string? User { get; set; }

        [JsonProperty("mailbox")]
        public string? Email { get; set; }

        [JsonProperty("from")]
        public string? From { get; set; }

        [JsonProperty("subject")]
        public string? Subject { get; set; }

        [JsonProperty("bodyPreview")]
        public string? BodyPreview { get; set; }

        [JsonProperty("bodyHtml")]
        public string? BodyHtml { get; set; }

        [JsonProperty("attachmentsCount")]
        public int? AttachmentsCount { get; set; }

        [JsonProperty("attachments")]
        public List<AttachmentResponse>? Attachments { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreateAt { get; set; }
    }

    public class AttachmentResponse
    {
        [JsonProperty("_id")]
        public int? Id { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }

        [JsonProperty("mimetype")]
        public string? MimeType { get; set; }

        [JsonProperty("filename")]
        public string? Filename { get; set; }

        [JsonProperty("cid")]
        public string? Cid { get; set; }
    }
}
