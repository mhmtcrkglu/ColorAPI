using Newtonsoft.Json;

namespace Colors.API.Models.Demo.Response
{
    
    public class GetUserFollowersModel
    {
        [JsonProperty("data")]
        public DataFollowers Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class DataFollowers
    {
        [JsonProperty("user")]
        public UserFollowers User { get; set; }
    }

    public class UserFollowers
    {
        [JsonProperty("edge_followed_by")]
        public EdgeFollowedBy EdgeFollowedBy { get; set; }

        [JsonProperty("edge_mutual_followed_by")]
        public EdgeMutualFollowedBy EdgeMutualFollowedBy { get; set; }
    }

    public class EdgeFollowedBy
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("page_info")]
        public PageInfoFollowers PageInfo { get; set; }

        [JsonProperty("edges")]
        public object[] Edges { get; set; }
    }

    public class PageInfoFollowers
    {
        [JsonProperty("has_next_page")]
        public bool HasNextPage { get; set; }

        [JsonProperty("end_cursor")]
        public object EndCursor { get; set; }
    }

    public class EdgeMutualFollowedBy
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("edges")]
        public object[] Edges { get; set; }
    }
}