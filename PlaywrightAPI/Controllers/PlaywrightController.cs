using Microsoft.AspNetCore.Mvc;

namespace PlaywrightAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaywrightController : ControllerBase
    {
            private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            private readonly ILogger<PlaywrightController> _logger;

            public PlaywrightController(ILogger<PlaywrightController> logger)
            {
                _logger = logger;
            }

            [HttpGet(Name = "GetRandomData")]
            public IEnumerable<PlaywrightData> Get(int startRange, int endRange)
            {
                return Enumerable.Range(startRange, endRange).Select(index => new PlaywrightData
                {
                    Date = DateTime.Now.AddDays(index),
                    RandomValue = Random.Shared.Next(startRange, endRange),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
            }
        
    }
}
