namespace WeatherConfigurationInterfaces
{
    public interface IWeatherConfigurationTemperature : IWeatherConfiguration
    {
        decimal TemperatureThreshold { get; set; }
    }
}