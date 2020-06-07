using Newtonsoft.Json;

namespace Colors.API.Models.Demo.Response
{
    public class GetUserInfoModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}