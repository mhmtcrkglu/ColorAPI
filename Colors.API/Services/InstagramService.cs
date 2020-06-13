using System.Net.Http;
using System.Threading.Tasks;
using Colors.API.Models.Demo.Response;
using Newtonsoft.Json;

namespace Colors.API.Services
{
    public interface IInstagramService
    {
        Task<GetUserInfoModel> GetUserInfo(string accessToken);
        Task<GetUserMediaModel> GetUserMedia(string accessToken);
    }
    public class InstagramService : IInstagramService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InstagramService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        readonly string baseUrl = "https://graph.instagram.com/";

        public async Task<GetUserInfoModel> GetUserInfo(string accessToken)
        {
            var userInfoUrl = baseUrl + "me?fields=id,ig_id,username,account_type,media_count&access_token={0}";

            var formattedUrl = string.Format(userInfoUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            var responseAsString = await result.Content.ReadAsStringAsync();

            var response =  JsonConvert.DeserializeObject<GetUserInfoModel>(responseAsString);

            var followers = await GetUserFollowers(response.IgId);

            var followersCount = followers.Data.User.EdgeFollowedBy.Count;
            
            var following = await GetUserFollowing(response.IgId);

            var followingCount = following.Data.User.EdgeFollow.Count;

            response.FollowersCount = followersCount;
            response.FollowingCount = followingCount;

            return response;
        }
        
        public async Task<GetUserMediaModel> GetUserMedia(string accessToken)
        {
            var userMediaUrl = baseUrl + "me/media?fields=id,caption,media_type,media_url,permalink,children,thumbnail_url,timestamp,username&access_token={0}";
            
            var formattedUrl = string.Format(userMediaUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            var responseAsString = await result.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<GetUserMediaModel>(responseAsString);
        }
        
        public async Task<GetUserFollowersModel> GetUserFollowers(string userId)
        {
            var userFollowersUrl= "https://www.instagram.com/graphql/query/?query_hash=c76146de99bb02f6415203be841dd25a&variables=";

            var graphModel = new UserGraphModel
            {
                Id = userId,
                IncludeReel = true,
                FetchMutual = false,
                First = 24
            };
            
            var graphSerializeModel = JsonConvert.SerializeObject(graphModel);

            userFollowersUrl = userFollowersUrl + graphSerializeModel;

            var result = await _httpClientFactory.CreateClient().GetAsync(userFollowersUrl);
            var responseAsString = await result.Content.ReadAsStringAsync();
            
            var response = JsonConvert.DeserializeObject<GetUserFollowersModel>(responseAsString);

            return response;
        }
        
        public async Task<GetUserFollowingModel> GetUserFollowing(string userId)
        {
            var userFollowersUrl= "https://www.instagram.com/graphql/query/?query_hash=d04b0a864b4b54837c0d870b0e77e076&variables=";

            var graphModel = new UserGraphModel
            {
                Id = userId,
                IncludeReel = true,
                FetchMutual = false,
                First = 24
            };
            
            var graphSerializeModel = JsonConvert.SerializeObject(graphModel);

            userFollowersUrl = userFollowersUrl + graphSerializeModel;

            var result = await _httpClientFactory.CreateClient().GetAsync(userFollowersUrl);
            var responseAsString = await result.Content.ReadAsStringAsync();
            
            var response = JsonConvert.DeserializeObject<GetUserFollowingModel>(responseAsString);
            
            return response;
        }
    }

    public class UserGraphModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("include_reel")]
        public bool IncludeReel { get; set; }

        [JsonProperty("fetch_mutual")]
        public bool FetchMutual { get; set; }

        [JsonProperty("first")]
        public long First { get; set; }
    }
}