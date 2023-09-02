using System.Text.Json;
using WeatherConfigurationInterfaces;
namespace ConfigurationFactory
{
    public class ConfigurationManager
    {
        private readonly Dictionary<string, IBotConfigurationFactory> botFactories = new Dictionary<string, IBotConfigurationFactory>
        {
            { "RainBot", new RainBotConfigurationFactory() },
            { "SunBot", new SunBotConfigurationFactory() },
            { "SnowBot", new SnowBotConfigurationFactory() }
        };

        public Dictionary<string, IWeatherConfiguration> LoadBotConfigurations(string configFilePath)
        {
            string configJson = File.ReadAllText(configFilePath);
            var botConfigData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(configJson);
            var configurations = new Dictionary<string, IWeatherConfiguration>();

            foreach (var singleBotConfigData in botConfigData)
            {
                if (botFactories.TryGetValue(singleBotConfigData.Key, out IBotConfigurationFactory factory))
                {
                    string fullTypeName = "WeatherBots." + singleBotConfigData.Key;
                    Type classType = Type.GetType(fullTypeName);
                    IWeatherConfiguration? config = JsonSerializer.Deserialize(singleBotConfigData.Value, classType) as IWeatherConfiguration;
                    IWeatherConfiguration botConfig = factory.CreateConfiguration(config);
                    configurations.Add(singleBotConfigData.Key, botConfig);
                }
                else
                {
                    Console.WriteLine($"Unsupported bot type: {singleBotConfigData.Key}");
                }
            }

            return configurations;
        }
    }
}