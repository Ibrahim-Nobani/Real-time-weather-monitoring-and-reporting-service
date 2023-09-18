using Models;
using WeatherConfigurationInterfaces;
namespace WeatherObserver
{
    public class WeatherBotObserver : IWeatherObserver
    {
        private IWeatherBot _weatherBot;

        public WeatherBotObserver(IWeatherBot bot)
        {
            _weatherBot = bot;
        }

        public void Update(WeatherData data)
        {
            _weatherBot.ProcessWeatherData(data);
        }
    }
}