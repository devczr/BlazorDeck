using BlazorDeck.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    
    private readonly ILogger<WeatherForecastController> _logger;
    IConfiguration _config;

    private static readonly string[] Summaries = new[]
    {
        "a", "b", "c", "d", "e", "f"
    };

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _config = configuration;
    }



    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IEnumerable<WeatherForecast> Get()
    {
        var rng = new Random();
        var configString = $"{_config["Deck:Config"]}";
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = configString
        })
        .ToArray();
    }
}
