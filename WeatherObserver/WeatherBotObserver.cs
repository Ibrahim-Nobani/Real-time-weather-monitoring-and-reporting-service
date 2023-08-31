using Models;
using WeatherConfigurationInterfaces;
namespace WeatherObserver
{
    public class WeatherBotObserver : IWeatherObserver
    {
        private IWeatherConfiguration _weatherBot;

        public WeatherBotObserver(IWeatherConfiguration bot)
        {
            _weatherBot = bot;
        }

        public void Update(WeatherData data)
        {
            _weatherBot.ProcessWeatherData(data);
        }
    }
}