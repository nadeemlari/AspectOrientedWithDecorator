using AspectOrientedWithDecorator.Filters;
using AspectOrientedWithDecorator.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspectOrientedWithDecorator.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [DurationLogging]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _weatherService.ForecastAsync();
    }
}