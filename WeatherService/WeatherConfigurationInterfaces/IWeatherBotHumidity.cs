namespace WeatherConfigurationInterfaces
{
    public interface IWeatherBotHumidity : IWeatherBot
    {
        decimal HumidityThreshold { get; set; }
    }
}