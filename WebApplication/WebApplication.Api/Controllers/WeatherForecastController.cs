using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Db;

namespace WebApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly WeatherDatabaseContext _weatherDatabaseContext;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherDatabaseContext weatherDatabaseContext)
        {
            _weatherDatabaseContext = weatherDatabaseContext;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherDatabaseContext.WeatherForecasts.Select(x=> new WeatherForecast() 
            { 
                Date= x.Date, 
                Summary = x.Summary, 
                TemperatureC = x.TemperatureC
            }).ToList();
        }
    }
}
