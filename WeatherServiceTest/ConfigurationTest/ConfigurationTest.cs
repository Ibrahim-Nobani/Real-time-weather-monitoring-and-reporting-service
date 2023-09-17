using System.Text.Json;
using ConfigurationManagers;
using Moq;
using WeatherBots;
using WeatherConfigurationInterfaces;
namespace ConfigurationManagerTests
{
    public class ConfigurationManagerTests
    {
        [Fact]
        public void LoadBotConfigurations_IsValidData_ReturnsConfigurations()
        {
            // Arrange
            var printingServiceMock = new Mock<IPrintingService>();
            var json = @"{
            ""RainBot"": {
                ""Enabled"": true,
                ""HumidityThreshold"": 70,
                ""Message"": ""It looks like it's about to pour down!""
            },
            ""SunBot"": {
                ""Enabled"": true,
                ""TemperatureThreshold"": 30,
                ""Message"": ""Wow, it's a scorcher out there!""
            },
            ""SnowBot"": {
                ""Enabled"": true,
                ""TemperatureThreshold"": 0,
                ""Message"": ""Brrr, it's getting chilly!""
            }
        }";
            var manager = new ConfigurationManager(printingServiceMock.Object);

            // Act
            var configurations = manager.LoadBotConfigurations(json);

            // Assert
            Assert.NotNull(configurations);
            Assert.Equal(3, configurations.Count);
            Assert.IsType<RainBot>(configurations["RainBot"]);
            Assert.IsType<SunBot>(configurations["SunBot"]);
            Assert.IsType<SnowBot>(configurations["SnowBot"]);
        }

        [Fact]
        public void LoadBotConfigurations_InvalidJson_ThrowsJsonException()
        {
            // Arrange
            var printingServiceMock = new Mock<IPrintingService>();
            var invalidJson = "Invalid JSON Data";
            var manager = new ConfigurationManager(printingServiceMock.Object);

            // Act & Assert
            Assert.Throws<JsonException>(() => manager.LoadBotConfigurations(invalidJson));
        }

        [Fact]
        public void LoadBotConfigurations_InvalidBotType_ThrowsArgumentException()
        {
            // Arrange
            var printingServiceMock = new Mock<IPrintingService>();
            var json = "{\"InvalidBotType\":{\"Property\":\"Invalid\"}}";
            var manager = new ConfigurationManager(printingServiceMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => manager.LoadBotConfigurations(json));
        }

        [Fact]
        public void LoadBotConfigurations_Exception_ThrowsJsonExceptionAndPrintsError()
        {
            // Arrange
            var printingServiceMock = new Mock<IPrintingService>();
            printingServiceMock.Setup(p => p.Print(It.IsAny<string>()));

            var invalidJson = "Invalid JSON Data";
            var manager = new ConfigurationManager(printingServiceMock.Object);

            // Act & Assert
            var ex = Assert.Throws<JsonException>(() => manager.LoadBotConfigurations(invalidJson));
            printingServiceMock.Verify(p => p.Print(It.IsAny<string>()), Times.Once);
        }
    }
}
