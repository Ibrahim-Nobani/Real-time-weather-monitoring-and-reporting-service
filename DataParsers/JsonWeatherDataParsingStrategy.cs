using Models;
using System.Text.Json;
namespace DataParsers
{
    public class JsonWeatherDataParsingStrategy : IWeatherDataParsingStrategy
    {
        public WeatherData ParseData(string dataFile)
        {
            string configJson = File.ReadAllText(dataFile);
            return JsonSerializer.Deserialize<WeatherData>(configJson);
        }
    }
}