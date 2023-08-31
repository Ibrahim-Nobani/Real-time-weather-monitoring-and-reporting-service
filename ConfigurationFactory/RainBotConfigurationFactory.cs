using WeatherConfigurationInterfaces;
using WeatherBots;
namespace ConfigurationFactory
{
    public class RainBotConfigurationFactory : IBotConfigurationFactory
    {
        public IWeatherConfiguration CreateConfiguration(dynamic botConfigData)
        {
            return new RainBot
            {
                Enabled = botConfigData.Enabled,
                Message = botConfigData.Message,
                HumidityThreshold = botConfigData.HumidityThreshold
            };
        }
    }
}