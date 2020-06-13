using Newtonsoft.Json;

namespace Colors.API.Models.Demo.Response
{
    
    public class GetUserFollowingModel
    {
        [JsonProperty("data")]
        public DataFollowing Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class DataFollowing
    {
        [JsonProperty("user")]
        public UserFollowing User { get; set; }
    }

    public class UserFollowing
    {
        [JsonProperty("edge_follow")]
        public EdgeFollow EdgeFollow { get; set; }
    }

    public class EdgeFollow
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("page_info")]
        public PageInfoFollowing PageInfo { get; set; }

        [JsonProperty("edges")]
        public object[] Edges { get; set; }
    }

    public class PageInfoFollowing
    {
        [JsonProperty("has_next_page")]
        public bool HasNextPage { get; set; }

        [JsonProperty("end_cursor")]
        public object EndCursor { get; set; }
    }
}