namespace WeatherConfigurationInterfaces
{
    public interface IWeatherBotTemperature : IWeatherBot
    {
        decimal TemperatureThreshold { get; set; }
    }
}