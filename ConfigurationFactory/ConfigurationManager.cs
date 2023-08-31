using System.Text.Json;
using WeatherConfigurationInterfaces;
namespace ConfigurationFactory
{
    public class ConfigurationManager
    {
        private readonly string configFilePath = "BotConfig.json";
        private readonly Dictionary<string, IBotConfigurationFactory> botFactories = new Dictionary<string, IBotConfigurationFactory>
    {
        { "RainBot", new RainBotConfigurationFactory() },
        { "SunBot", new SunBotConfigurationFactory() },
        { "SnowBot", new SnowBotConfigurationFactory() }
    };

        public Dictionary<string, IWeatherConfiguration> LoadBotConfigurations()
        {
            string configJson = File.ReadAllText(configFilePath);
            var botConfigData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(configJson);
            var configurations = new Dictionary<string, IWeatherConfiguration>();

            foreach (var kvp in botConfigData)
            {
                if (botFactories.TryGetValue(kvp.Key, out IBotConfigurationFactory factory))
                {
                    string fullTypeName = "WeatherBots." + kvp.Key;
                    Type classType = Type.GetType(fullTypeName);
                    IWeatherConfiguration? config = JsonSerializer.Deserialize(kvp.Value, classType) as IWeatherConfiguration;
                    IWeatherConfiguration botConfig = factory.CreateConfiguration(config);
                    configurations.Add(kvp.Key, botConfig);
                }
                else
                {
                    Console.WriteLine($"Unsupported bot type: {kvp.Key}");
                }
            }

            return configurations;
        }
    }
}