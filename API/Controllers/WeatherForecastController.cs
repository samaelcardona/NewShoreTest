using Microsoft.AspNetCore.Mvc;
using NewShoreTest.Business.Interfaces;

namespace NewShoreTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IJourneyService journeyService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IJourneyService journeyService)
        {
            _logger = logger;
            this.journeyService = journeyService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Response = journeyService.GetJourneyReponse("MZL", "BCN")
            })
            .ToArray();
        }
    }
}
