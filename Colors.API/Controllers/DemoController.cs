using System.Collections.Generic;
using System.Threading.Tasks;
using Colors.API.Models.Demo;
using Colors.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colors.API.Controllers
{
    /// <summary>
    /// A set of APIs to convert colors and compute color metrics
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IInstagramService _instagramService;

        public DemoController(IInstagramService instagramService)
        {
            _instagramService = instagramService;
        }

        [HttpGet("names")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<string>> DemoNameList()
        {
            var response = new List<string>();
            response.Add("Mustafa Türkan");
            response.Add("Mehmet Çürükoğlu");
            return Ok(response);
        }

        [HttpGet("user-info")]
        [ProducesResponseType(typeof(GetUserInfoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetUserInfoModel>> GetUserInfo([FromQuery] string accessToken)
        {
            var result = await _instagramService.GetUserInfo(accessToken);
            return Ok(result);
        }
        
        
    }
}