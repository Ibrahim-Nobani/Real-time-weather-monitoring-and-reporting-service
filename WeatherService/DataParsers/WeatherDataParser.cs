using Models;
namespace DataParsers
{
    public class WeatherDataParser
    {
        private IWeatherDataParsingStrategy _parsingStrategy;

        public WeatherDataParser(IWeatherDataParsingStrategy parsingStrategy)
        {
            _parsingStrategy = parsingStrategy;
        }

        public WeatherData Parse(string data)
        {
            return _parsingStrategy.ParseData(data);
        }
    }
}