using System;
using System.Collections.Generic;
using System.Linq;
using WeatherObserver;
using ConfigurationFactory;
using Models;
using DataParsers;
using WeatherConfigurationInterfaces;
using WeatherBots;
using InputHelpers;
public class Program
{
    static void Main(string[] args)
    {
        WeatherMonitor weatherMonitor = new WeatherMonitor();
        ConfigurationManager configurationManager = new ConfigurationManager();

        Dictionary<ParsingStrategyOption, IWeatherDataParsingStrategy> parsingStrategies =
            new Dictionary<ParsingStrategyOption, IWeatherDataParsingStrategy>
        {
            { ParsingStrategyOption.JsonOption, new JsonWeatherDataParsingStrategy() },
            { ParsingStrategyOption.XmlOption, new XmlWeatherDataParsingStrategy() }
        };

        while (true)
        {
            ParsingStrategyOption option = GetParsingStrategyOptionFromUser();

            if (option == ParsingStrategyOption.Exit)
            {
                break;
            }

            IWeatherDataParsingStrategy parsingStrategy = parsingStrategies[option];
            WeatherDataParser dataParser = new WeatherDataParser(parsingStrategy);

            string userInputFile = readConsoleInputFile(option);
            WeatherData weatherData = dataParser.Parse(userInputFile);

            ConfigureBots(weatherMonitor, configurationManager);
            weatherMonitor.NotifyObservers(weatherData);
        }
    }

    static ParsingStrategyOption GetParsingStrategyOptionFromUser()
    {
        Console.WriteLine("Select parsing strategy:");
        Console.WriteLine($"{(int)ParsingStrategyOption.JsonOption}. JSON");
        Console.WriteLine($"{(int)ParsingStrategyOption.XmlOption}. XML");
        Console.WriteLine($"{(int)ParsingStrategyOption.Exit}. Exit");

        while (true)
        {
            int choice = ReadInputHelper.GetIntInput("Enter Your Choice: ");
            if (Enum.IsDefined(typeof(ParsingStrategyOption), choice))
            {
                return (ParsingStrategyOption)choice;
            }
            Console.WriteLine("Invalid choice. Please enter a valid option.");
        }
    }

    static string readConsoleInputFile(ParsingStrategyOption option)
    {
        if (option == ParsingStrategyOption.JsonOption)
        {
            return FileInputHelper.ReadJsonFile("Enter JSON weather data file: ");
        }
        else if (option == ParsingStrategyOption.XmlOption)
        {
            return FileInputHelper.ReadXmlFile("Enter XML weather data file: ");
        }
        return null;
    }

    static void ConfigureBots(WeatherMonitor weatherMonitor, ConfigurationManager configurationManager)
    {
        string configFilePath = FileInputHelper.ReadJsonFile("Enter bot configuration data file: ");

        Dictionary<string, IWeatherConfiguration> botConfigurations = configurationManager.LoadBotConfigurations(configFilePath);
        botConfigurations.Where(botConfiguration => botConfiguration.Value.Enabled).ToList()
        .ForEach(botConfiguration => weatherMonitor.AddObserver(new WeatherBotObserver(botConfiguration.Value)));
    }
}