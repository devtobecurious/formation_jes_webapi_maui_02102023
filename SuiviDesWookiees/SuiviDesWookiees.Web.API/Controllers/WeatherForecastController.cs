using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SuiviDesWookiees.Libs;
using SuiviDesWookiees.Libs.Services;

namespace SuiviDesWookiees.Web.API.Controllers
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
        private readonly IHostEnvironment environment;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHostEnvironment environment,
                                        IOptions<GameSetting> options)
        {
            _logger = logger;
            this.environment = environment;

            var gameSetting = options.Value;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(IWookieeService service)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}