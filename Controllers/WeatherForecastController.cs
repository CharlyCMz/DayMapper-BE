using Microsoft.AspNetCore.Mvc;

namespace DayMapper_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> WeatherForecastsList = new List<WeatherForecast>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if (WeatherForecastsList == null || !WeatherForecastsList.Any())
            {
                WeatherForecastsList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return WeatherForecastsList;
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            WeatherForecastsList.Add(weatherForecast);

            return Ok();
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            WeatherForecastsList.RemoveAt(index);

            return Ok();
        }
    }
}
