using System.Xml.Linq;
using Models;
namespace DataParsers
{
    public class XmlWeatherDataParsingStrategy : IWeatherDataParsingStrategy
    {
        public WeatherData ParseData(string dataFile)
        {
            string configXml = File.ReadAllText(dataFile);
            XElement xml = XElement.Parse(configXml);
            return new WeatherData
            {
                Location = xml.Element("Location").Value,
                Temperature = Convert.ToDecimal(xml.Element("Temperature").Value),
                Humidity = Convert.ToDecimal(xml.Element("Humidity").Value)
            };
        }
    }
}