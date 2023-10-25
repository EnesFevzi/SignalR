using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.API.Enums;
using SıgnalR.API.Models;
using SıgnalR.API.Service;

namespace SıgnalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidsController : ControllerBase
    {
        private readonly CovidService _covidService;

        public CovidsController(CovidService covidService)
        {
            _covidService = covidService;
        }


        [HttpPost]
        public async Task<IActionResult> SaveCovid(Covid covid)
        {
            await _covidService.SaveCovid(covid);
            IQueryable<Covid> covids = _covidService.GetList();
            return Ok(covids);
        }
        [HttpGet]
        public async Task<IActionResult> InitializeCovid()
        {
           Random random = new Random();

            Enumerable.Range(1, 10).ToList().ForEach(async x =>
            {
                foreach (City item in Enum.GetValues(typeof(City)))
                {
                    var newcovid = new Covid { City=item,Count=random.Next(100,1000),CovidDate=DateTime.Now.AddDays(2)};
                    await _covidService.SaveCovid(newcovid);
                    System.Threading.Thread.Sleep(1000);
                }


            });
            return Ok();
        }

    }
}
