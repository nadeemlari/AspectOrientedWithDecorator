using System.Diagnostics;

namespace AspectOrientedWithDecorator.Services;

public class LoggedWeatherService : IWeatherService
{
    private readonly IWeatherService _weatherService;

    public LoggedWeatherService(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IEnumerable<WeatherForecast>> ForecastAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return await _weatherService.ForecastAsync();
        }
        finally
        {
            sw.Stop();
            Console.WriteLine($"{nameof(LoggedWeatherService)}.{nameof(ForecastAsync)} executed in {sw.ElapsedMilliseconds}ms");
        }
    }
}