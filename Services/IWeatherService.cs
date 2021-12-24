namespace AspectOrientedWithDecorator.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>>ForecastAsync();
}