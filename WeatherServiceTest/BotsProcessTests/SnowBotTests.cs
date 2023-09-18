using Xunit;
using Moq;
using WeatherBots;
using Models;

namespace BotsProcessTests
{
    public class SnowBotTests
    {
        private Mock<IPrintingService> mockPrintingService;
        private SnowBot snowBot;

        public SnowBotTests()
        {
            // Common setup before each test
            mockPrintingService = new Mock<IPrintingService>();
            snowBot = new SnowBot
            {
                Enabled = true,
                Message = "Jon Snowing",
                TemperatureThreshold = 0.6m
            };
            snowBot.SetPrintingService(mockPrintingService.Object);
        }

        [Fact]
        public void SnowBotProcessWeatherData_WhenTemperatureIsBelowThreshold_ShouldCallPrintingService()
        {
            // Arrange
            var mockWeatherData = new Mock<IWeatherData>();
            mockWeatherData.Setup(weatherData => weatherData.Temperature).Returns(0.5m);

            // Act
            snowBot.ProcessWeatherData(mockWeatherData.Object);

            // Assert
            mockPrintingService.Verify(p => p.Print("SnowBot activated!"), Times.Once);
            mockPrintingService.Verify(p => p.Print($"SnowBot: \"{snowBot.Message}\""), Times.Once);
        }

        [Fact]
        public void SnowBotProcessWeatherData_WhenTemperatureIsAboveThreshold_ShouldNotCallPrintingService()
        {
            // Arrange
            var mockWeatherData = new Mock<IWeatherData>();
            mockWeatherData.Setup(weatherData => weatherData.Temperature).Returns(0.7m);

            // Act
            snowBot.ProcessWeatherData(mockWeatherData.Object);

            // Assert
            mockPrintingService.Verify(p => p.Print(It.IsAny<string>()), Times.Never);
        }
    }
}
