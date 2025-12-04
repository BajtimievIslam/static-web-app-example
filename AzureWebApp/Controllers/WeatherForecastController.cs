using AzureWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public WeatherForecastController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            var weatherEntities = await _context.Weathers.ToListAsync();

            var weatherForecasts = weatherEntities.Select(entity => new WeatherForecast
            {
                Date = entity.Date,
                TemperatureC = entity.TemperatureC,
                Summary = entity.Summary
            }).ToList();

            return Ok(weatherForecasts);
        }
    }
}
