using System;
using System.Collections.Generic;
using System.Text.Json;
using WeatherBots;
using WeatherConfigurationInterfaces;

namespace ConfigurationManagers
{
    public class ConfigurationManager
    {
        private readonly IPrintingService _printingService;

        public ConfigurationManager(IPrintingService printingService)
        {
            _printingService = printingService;
        }

        public Dictionary<string, IWeatherBot> LoadBotConfigurations(string configData)
        {
            try
            {
                var botConfigData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(configData);
                var configurations = new Dictionary<string, IWeatherBot>();

                foreach (var singleBotConfigData in botConfigData)
                {
                    var bot = CreateBotInstance(singleBotConfigData.Key, singleBotConfigData.Value);
                    configurations.Add(singleBotConfigData.Key, bot);
                }

                return configurations;
            }
            catch (JsonException ex)
            {
                _printingService.Print($"JSON deserialization error: {ex.Message}");
                throw;
            }
        }

        private IWeatherBot CreateBotInstance(string botType, dynamic botConfig)
        {
            switch (botType)
            {
                case "RainBot":
                    var rainBot = JsonSerializer.Deserialize<RainBot>(botConfig);
                    rainBot.SetPrintingService(_printingService);
                    return rainBot;

                case "SnowBot":
                    var snowBot = JsonSerializer.Deserialize<SnowBot>(botConfig);
                    snowBot.SetPrintingService(_printingService);
                    return snowBot;

                case "SunBot":
                    var sunBot = JsonSerializer.Deserialize<SunBot>(botConfig);
                    sunBot.SetPrintingService(_printingService);
                    return sunBot;

                default:
                    throw new ArgumentException($"Unsupported bot type: {botType}");
            }
        }
    }
}
