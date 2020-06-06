using System.Collections.Generic;
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
    }
}