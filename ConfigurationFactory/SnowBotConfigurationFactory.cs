using WeatherConfigurationInterfaces;
using WeatherBots;
namespace ConfigurationFactory
{
    public class SnowBotConfigurationFactory : IBotConfigurationFactory
    {
        public IWeatherConfiguration CreateConfiguration(dynamic botConfigData)
        {
            return new SnowBot
            {
                Enabled = botConfigData.Enabled,
                Message = botConfigData.Message,
                TemperatureThreshold = botConfigData.TemperatureThreshold
            };
        }
    }
}