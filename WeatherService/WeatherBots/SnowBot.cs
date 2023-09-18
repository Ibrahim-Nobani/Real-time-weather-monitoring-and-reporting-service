using Models;
using WeatherConfigurationInterfaces;
namespace WeatherBots
{
    public class SnowBot : IWeatherBotTemperature
    {
        public bool Enabled { get; set; }
        public string Message { get; set; }
        public decimal TemperatureThreshold { get; set; }
        private IPrintingService _printingService; // Remove readonly

        public void SetPrintingService(IPrintingService printingService)
        {
            _printingService = printingService;
        }

        public void ProcessWeatherData(IWeatherData data)
        {
            if (data.Temperature < TemperatureThreshold)
            {
                _printingService.Print("SnowBot activated!");
                _printingService.Print($"SnowBot: \"{Message}\"");
            }
        }
    }
}