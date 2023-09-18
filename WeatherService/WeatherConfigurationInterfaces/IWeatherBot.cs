using Models;
namespace WeatherConfigurationInterfaces
{
    public interface IWeatherBot
    {
        bool Enabled { get; set; }
        string Message { get; set; }
        void ProcessWeatherData(IWeatherData data);
    }
}