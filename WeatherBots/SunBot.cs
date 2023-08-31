using Models;
using WeatherConfigurationInterfaces;
namespace WeatherBots
{
    public class SunBot : IWeatherConfigurationTemperature
    {
        public bool Enabled { get; set; }
        public string Message { get; set; }
        public decimal TemperatureThreshold { get; set; }

        public void ProcessWeatherData(WeatherData data)
        {
            if (data.Temperature > TemperatureThreshold)
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine($"SunBot: \"{Message}\"");
            }
        }
    }
}