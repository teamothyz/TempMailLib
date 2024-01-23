using Newtonsoft.Json;

namespace TempMailLib
{
    public class MailboxResponse
    {
        [JsonProperty("mailbox")]
        public string? Email { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}
