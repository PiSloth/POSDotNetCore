using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POSDotNetCore.BirdWebApi.Models;

namespace POSDotNetCore.BirdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/birds";

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            //var response = await client.GetAsync("https://burma-project-ideas.vercel.app/birds");
            var response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<BirdDataModel> birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(json)!;

                /*
                List<BirdViewModel> lst = birds.Select(bird => new BirdViewModel
                {
                    BirdId = bird.Id,
                    BirdName = bird.BirdMyanmarName,
                    Desc = bird.Description,
                    Img = $"https://burma-project-ideas.vercel.app/birds/{bird.ImagePath }",
                }).ToList();
                */

                List<BirdViewModel> lst = birds.Select(bird => Change(bird)).ToList();
                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://burma-project-ideas.vercel.app/birds/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BirdDataModel bird = JsonConvert.DeserializeObject<BirdDataModel>(json)!;

                /* BirdViewModel item = new BirdViewModel
                 {
                     BirdId = bird.Id,
                     BirdName = bird.BirdMyanmarName,
                     Desc = bird.Description,
                     Img = $"https://burma-project-ideas.vercel.app/birds/{bird.ImagePath}",
                 }; */

                BirdViewModel item = Change(bird);
                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }

        private BirdViewModel Change (BirdDataModel bird)
        {
            var item = new BirdViewModel
            {
                BirdId = bird.Id,
                BirdName = bird.BirdMyanmarName,
                Desc = bird.Description,
                Img = $"{_url}/{bird.ImagePath}",
            };
            return item;
        }
    }
}
