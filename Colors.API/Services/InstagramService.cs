using System.Net.Http;
using System.Threading.Tasks;
using Colors.API.Models.Demo.Response;
using Newtonsoft.Json;

namespace Colors.API.Services
{
    public interface IInstagramService
    {
        Task<GetUserInfoModel> GetUserInfo(string accessToken);
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
            var userInfoUrl = baseUrl + "me?fields=id,username&access_token={0}";
            
            var formattedUrl = string.Format(baseUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            var responseAsString = await result.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<GetUserInfoModel>(responseAsString);
        }
    }
}