using Models;
namespace DataParsers
{
    public interface IWeatherDataParsingStrategy
    {
        WeatherData ParseData(string dataFile);
    }
}