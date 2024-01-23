using Newtonsoft.Json;
using System.Net;

namespace TempMailLib
{
    public class TempMailClient
    {
        /// <summary>
        /// Sử dụng proxy với format http://ip:port nếu cần get số lượng lớn email
        /// Không sử dụng proxy sẽ bị giới hạn request do temp-mail chặn
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<MailboxResponse> GetNewEmail(string? proxy = null, string? proxyusername = null,
            string? proxypassword = null, CancellationToken? token = null)
        {
            var content = string.Empty;
            try
            {
                using var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
                };
                if (!string.IsNullOrWhiteSpace(proxy))
                {
                    var webProxy = new WebProxy(proxy);
                    if (!string.IsNullOrEmpty(proxyusername) && !string.IsNullOrEmpty(proxypassword))
                    {
                        webProxy.Credentials = new NetworkCredential(proxyusername, proxypassword);
                    }
                    handler.Proxy = webProxy;
                }
                using var client = new HttpClient(handler)
                {
                    DefaultRequestVersion = HttpVersion.Version20
                };
                client.DefaultRequestHeaders.Add("Origin", "https://temp-mail.org");
                client.DefaultRequestHeaders.Add("Referer", "https://temp-mail.org/");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36 Edg/120.0.0.0");
                token ??= CancellationToken.None;

                using var response = await client.PostAsync("https://web2.temp-mail.org/mailbox", null, token.Value);
                content = await response.Content.ReadAsStringAsync(token.Value);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<MailboxResponse>(content) ?? throw new Exception("Deserialize response null");
            }
            catch (Exception ex)
            {
                throw new Exception($"Get new email failed. Response content: [{content}]. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Sử dụng proxy với format http://ip:port nếu cần get số lượng lớn email
        /// Không sử dụng proxy sẽ bị giới hạn request do temp-mail chặn
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<MessageCollectionResponse> GetMessages(string emailToken, string? proxy = null,
            string? proxyusername = null, string? proxypassword = null, CancellationToken? token = null)
        {
            var content = string.Empty;
            try
            {
                using var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
                };
                if (!string.IsNullOrWhiteSpace(proxy))
                {
                    var webProxy = new WebProxy(proxy);
                    if (!string.IsNullOrEmpty(proxyusername) && !string.IsNullOrEmpty(proxypassword))
                    {
                        webProxy.Credentials = new NetworkCredential(proxyusername, proxypassword);
                    }
                    handler.Proxy = webProxy;
                }
                using var client = new HttpClient(handler)
                {
                    DefaultRequestVersion = HttpVersion.Version20
                };
                client.DefaultRequestHeaders.Add("Origin", "https://temp-mail.org");
                client.DefaultRequestHeaders.Add("Referer", "https://temp-mail.org/");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36 Edg/120.0.0.0");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {emailToken}");
                token ??= CancellationToken.None;

                using var response = await client.GetAsync("https://web2.temp-mail.org/messages", token.Value);
                content = await response.Content.ReadAsStringAsync(token.Value);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<MessageCollectionResponse>(content) ?? throw new Exception("Deserialize response null");
            }
            catch (Exception ex)
            {
                throw new Exception($"Get messages failed. Response content: [{content}]. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Sử dụng proxy với format http://ip:port nếu cần get số lượng lớn email
        /// Không sử dụng proxy sẽ bị giới hạn request do temp-mail chặn
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<MessageDetailsResponse> ReadMessage(string messageId, string emailToken,
            string? proxy = null, string? proxyusername = null, string? proxypassword = null, CancellationToken? token = null)
        {
            var content = string.Empty;
            try
            {
                using var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
                };
                if (!string.IsNullOrWhiteSpace(proxy))
                {
                    var webProxy = new WebProxy(proxy);
                    if (!string.IsNullOrEmpty(proxyusername) && !string.IsNullOrEmpty(proxypassword))
                    {
                        webProxy.Credentials = new NetworkCredential(proxyusername, proxypassword);
                    }
                    handler.Proxy = webProxy;
                }
                using var client = new HttpClient(handler)
                {
                    DefaultRequestVersion = HttpVersion.Version20
                };
                client.DefaultRequestHeaders.Add("Origin", "https://temp-mail.org");
                client.DefaultRequestHeaders.Add("Referer", "https://temp-mail.org/");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36 Edg/120.0.0.0");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {emailToken}");
                token ??= CancellationToken.None;

                using var response = await client.GetAsync($"https://web2.temp-mail.org/messages/{messageId}", token.Value);
                content = await response.Content.ReadAsStringAsync(token.Value);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<MessageDetailsResponse>(content) ?? throw new Exception("Deserialize response null");
            }
            catch (Exception ex)
            {
                throw new Exception($"Read message [{messageId}] failed. Response content: [{content}]. Error: {ex.Message}");
            }
        }
    }
}
