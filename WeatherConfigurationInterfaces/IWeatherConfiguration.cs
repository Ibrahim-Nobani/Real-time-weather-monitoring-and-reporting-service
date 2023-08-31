using Models;
namespace WeatherConfigurationInterfaces
{
    public interface IWeatherConfiguration
    {
        bool Enabled { get; set; }
        string Message { get; set; }
        void ProcessWeatherData(WeatherData data);
    }
}