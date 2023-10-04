using DiscoverDotnetEight.AppCode;
using Microsoft.AspNetCore.Mvc;

namespace DiscoverDotnetEight.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Planet> Get()
        {
            Planet[] planets = [new(), new()]; // Collection expressions
            Planet[] planets2 = [new(), new(), new()]; // Collection expressions

            Planet[] planetsComplete = [.. planets, .. planets2];


            var movePlanets = (Planet planet, int x = 0, int y = 3) =>
            {
                planet.Position = new(x, y);

                (var xr, var yr) = planet.Position;
            };
            movePlanets(planets[0], 1, 2);

            return planets;
        }
    }
}