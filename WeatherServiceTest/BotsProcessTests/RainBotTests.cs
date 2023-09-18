using Xunit;
using WeatherBots;
using Moq;
using Models;

namespace BotsProcessTests
{
    public class RainBotTests
    {
        private Mock<IPrintingService> mockPrintingService;
        private RainBot rainBot;

        public RainBotTests()
        {
            mockPrintingService = new Mock<IPrintingService>();
            rainBot = new RainBot
            {
                Enabled = true,
                Message = "It's raining!",
                HumidityThreshold = 0.6m
            };
            rainBot.SetPrintingService(mockPrintingService.Object);
        }

        [Fact]
        public void RainBotProcessWeatherData_WhenHumidityIsAboveThreshold_ShouldCallPrintingService()
        {
            // Arrange
            var mockWeatherData = new Mock<IWeatherData>();
            mockWeatherData.Setup(w => w.Humidity).Returns(0.7m);

            // Act
            rainBot.ProcessWeatherData(mockWeatherData.Object);

            // Assert
            mockPrintingService.Verify(p => p.Print("RainBot activated!"), Times.Once);
            mockPrintingService.Verify(p => p.Print($"RainBot: \"{rainBot.Message}\""), Times.Once);
        }

        [Fact]
        public void RainBotProcessWeatherData_WhenHumidityIsBelowThreshold_ShouldNotCallPrintingService()
        {
            // Arrange
            var mockWeatherData = new Mock<IWeatherData>();
            mockWeatherData.Setup(w => w.Humidity).Returns(0.5m);

            // Act
            rainBot.ProcessWeatherData(mockWeatherData.Object);

            // Assert
            mockPrintingService.Verify(p => p.Print(It.IsAny<string>()), Times.Never);
        }
    }
}
