using WeatherConfigurationInterfaces;
using WeatherBots;
namespace ConfigurationFactory
{
    public class SunBotConfigurationFactory : IBotConfigurationFactory
    {
        public IWeatherConfiguration CreateConfiguration(dynamic botConfigData)
        {
            return new SunBot
            {
                Enabled = botConfigData.Enabled,
                Message = botConfigData.Message,
                TemperatureThreshold = botConfigData.TemperatureThreshold
            };
        }
    }
}