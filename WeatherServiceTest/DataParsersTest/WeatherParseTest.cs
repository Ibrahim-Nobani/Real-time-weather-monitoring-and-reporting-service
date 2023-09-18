using System.Text.Json;
using System.Xml;
using DataParsers;
namespace WeatherDataParserTests
{
    public class WeatherDataParserTests
    {
        [Fact]
        public void WeatherParseJson_IsValidData_ReturnsWeatherData()
        {
            // Arrange
            var jsonStrategy = new JsonWeatherDataParsingStrategy();
            var parser = new WeatherDataParser(jsonStrategy);
            var jsonData = "{\"Location\":\"Test Location\",\"Temperature\":25.5,\"Humidity\":50.0}";

            // Act
            var parsedData = parser.Parse(jsonData);

            // Assert
            Assert.Equal("Test Location", parsedData.Location);
            Assert.Equal(25.5M, parsedData.Temperature);
            Assert.Equal(50.0M, parsedData.Humidity);
        }

        [Fact]
        public void WeatherParseXml_IsValidXml_ReturnsWeatherData()
        {
            // Arrange
            var xmlStrategy = new XmlWeatherDataParsingStrategy();
            var parser = new WeatherDataParser(xmlStrategy);
            var xmlData = "<WeatherData><Location>Test Location</Location><Temperature>25.5</Temperature><Humidity>50.0</Humidity></WeatherData>";

            // Act
            var parsedData = parser.Parse(xmlData);

            // Assert
            Assert.Equal("Test Location", parsedData.Location);
            Assert.Equal(25.5M, parsedData.Temperature);
            Assert.Equal(50.0M, parsedData.Humidity);
        }

        [Fact]
        public void WeatherParseXml_IsInvalidXml_ThrowsException()
        {
            // Arrange
            var xmlStrategy = new XmlWeatherDataParsingStrategy();
            var parser = new WeatherDataParser(xmlStrategy);
            var invalidXmlData = "Invalid Xml";

            // Act & Assert
            Assert.Throws<XmlException>(() => parser.Parse(invalidXmlData));
        }
        [Fact]
        public void WeatherParseJsonStrategy_IsInvalidJson_ThrowsException()
        {
            // Arrange
            var jsonStrategy = new JsonWeatherDataParsingStrategy();
            var parser = new WeatherDataParser(jsonStrategy);
            var invalidJsonData = "Invalid JSON";

            // Act & Assert
            Assert.Throws<JsonException>(() => parser.Parse(invalidJsonData));
        }
    }
}