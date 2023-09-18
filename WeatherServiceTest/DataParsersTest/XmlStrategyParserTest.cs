using System.Xml;
using DataParsers;
namespace XmlStrategyParserTest
{
    public class XmlStrategyParserTest
    {
        [Fact]
        public void ParseData_ValidXml_ReturnsWeatherData()
        {
            // Arrange
            var strategy = new XmlWeatherDataParsingStrategy();
            var xmlData = "<WeatherData><Location>Test Location</Location><Temperature>25.5</Temperature><Humidity>50.0</Humidity></WeatherData>";

            // Act
            var parsedData = strategy.ParseData(xmlData);

            // Assert
            Assert.Equal("Test Location", parsedData.Location);
            Assert.Equal(25.5M, parsedData.Temperature);
            Assert.Equal(50.0M, parsedData.Humidity);
        }

        [Fact]
        public void ParseData_InvalidXml_ThrowsException()
        {
            // Arrange
            var strategy = new XmlWeatherDataParsingStrategy();
            var invalidXmlData = "Invalid XML";

            // Act & Assert
            Assert.Throws<XmlException>(() => strategy.ParseData(invalidXmlData));
        }
    }
}
