using Models;
using WeatherConfigurationInterfaces;
namespace WeatherBots
{
    public class SnowBot : IWeatherConfigurationTemperature
    {
        public bool Enabled { get; set; }
        public string Message { get; set; }
        public decimal TemperatureThreshold { get; set; }

        public void ProcessWeatherData(WeatherData data)
        {
            if (data.Temperature < TemperatureThreshold)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine($"SnowBot: \"{Message}\"");
            }
        }
    }
}