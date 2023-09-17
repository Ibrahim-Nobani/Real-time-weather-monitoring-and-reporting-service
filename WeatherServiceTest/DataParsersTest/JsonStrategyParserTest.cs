using System.IO;
using System.Text.Json;
using System.Xml;
using DataParsers;
using Models;
using Xunit;

namespace JsonStrategyParserTests
{
    public class JsonStrategyParserTests
    {
        [Fact]
        public void JsonWeatherDataParsingStrategy_IsValidJson_ReturnsWeatherData()
        {
            // Arrange
            var strategy = new JsonWeatherDataParsingStrategy();
            var jsonData = "{\"Location\":\"Test Location\",\"Temperature\":25.5,\"Humidity\":50.0}";

            // Act
            var parsedData = strategy.ParseData(jsonData);

            // Assert
            Assert.Equal("Test Location", parsedData.Location);
            Assert.Equal(25.5M, parsedData.Temperature);
            Assert.Equal(50.0M, parsedData.Humidity);
        }

        [Fact]
        public void ParseData_InvalidJson_ThrowsException()
        {
            // Arrange
            var strategy = new JsonWeatherDataParsingStrategy();
            var invalidJson = "Invalid JSON";

            // Act & Assert
            Assert.Throws<JsonException>(() => strategy.ParseData(invalidJson));
        }
    }
}
