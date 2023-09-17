using System;
using System.Collections.Generic;
using System.Linq;
using WeatherObserver;
using WeatherConfigurationInterfaces;
using WeatherBots;
using Models;
namespace ConfigurationManagers
{
    public class ObserverBotsConfigurationManager
    {
        private readonly ConfigurationManager _configurationManager;
        private readonly WeatherMonitor _weatherMonitor;

        public ObserverBotsConfigurationManager(ConfigurationManager configurationManager, WeatherMonitor weatherMonitor)
        {
            _configurationManager = configurationManager;
            _weatherMonitor = weatherMonitor;
        }

        public void AddEnabledBotObservers(string configData)
        {
            Dictionary<string, IWeatherBot> botConfigurations = _configurationManager.LoadBotConfigurations(configData);
            botConfigurations
                .Where(botConfiguration => botConfiguration.Value.Enabled)
                .ToList()
                .ForEach(botConfiguration => _weatherMonitor.AddObserver(new WeatherBotObserver(botConfiguration.Value)));
        }
    }
}
