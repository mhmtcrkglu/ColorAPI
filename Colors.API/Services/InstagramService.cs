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

            return JsonConvert.DeserializeObject<GetUserInfoModel>(responseAsString);
        }
        
        public async Task<GetUserMediaModel> GetUserMedia(string accessToken)
        {
            var userInfoUrl = baseUrl + "me/media?fields=id,caption,media_type,media_url,permalink,children,thumbnail_url,timestamp,username&access_token={0}";
            
            var formattedUrl = string.Format(userInfoUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            var responseAsString = await result.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<GetUserMediaModel>(responseAsString);
        }
    }
}