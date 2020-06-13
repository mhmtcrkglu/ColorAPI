using Newtonsoft.Json;

namespace Colors.API.Models.Demo.Response
{
    public class GetUserInfoModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ig_id")]
        public string IgId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        [JsonProperty("media_count")]
        public long MediaCount { get; set; }
    }
}