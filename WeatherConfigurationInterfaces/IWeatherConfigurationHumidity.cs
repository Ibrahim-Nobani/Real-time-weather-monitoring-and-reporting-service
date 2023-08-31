namespace WeatherConfigurationInterfaces
{
    public interface IWeatherConfigurationHumidity : IWeatherConfiguration
    {
        decimal HumidityThreshold { get; set; }
    }
}