using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POSDotNetCore.BirdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://burma-project-ideas.vercel.app/birds");
            if(response.IsSuccessStatusCode)
            {

            }
            return Ok();
        }
    }
}
