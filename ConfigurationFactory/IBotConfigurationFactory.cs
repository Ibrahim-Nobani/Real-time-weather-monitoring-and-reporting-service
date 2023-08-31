using WeatherConfigurationInterfaces;
namespace ConfigurationFactory
{
    public interface IBotConfigurationFactory
    {
        IWeatherConfiguration CreateConfiguration(dynamic botConfigData);
    }
}