using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
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

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "ExceptionThrowing")]
        public string GetException()
        {
            var value = new Random().Next(0, 10);
            if (value > 5)
            {
                return  value.ToString();
            }
            throw new Exception("throw an exception for test");
            //return "exception throwing";
        }

        [HttpPost]
        public IActionResult Post([FromForm] string input)
        {
            var value = new Random().Next(10, 20);
            if (value > 5)
            {
                return Ok(value.ToString());
            }

            throw new Exception("thow an exception on Post method");
        }
    }
}