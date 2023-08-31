using Models;
using WeatherConfigurationInterfaces;
namespace WeatherBots
{
    public class RainBot : IWeatherConfigurationHumidity
    {
        public bool Enabled { get; set; }
        public string Message { get; set; }
        public decimal HumidityThreshold { get; set; }

        public void ProcessWeatherData(WeatherData data)
        {
            if (data.Humidity > HumidityThreshold)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine($"RainBot: \"{Message}\"");
            }
        }
    }
}
