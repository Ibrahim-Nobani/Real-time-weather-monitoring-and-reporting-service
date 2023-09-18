using Newtonsoft.Json;
using WeatherConfigurationInterfaces;

public class RainBot : IWeatherBotHumidity
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public decimal HumidityThreshold { get; set; }

    private IPrintingService _printingService;

    public void SetPrintingService(IPrintingService printingService)
    {
        _printingService = printingService;
    }

    public void ProcessWeatherData(IWeatherData data)
    {
        if (data.Humidity > HumidityThreshold)
        {
            _printingService.Print("RainBot activated!");
            _printingService.Print($"RainBot: \"{Message}\"");
        }
    }
}
