using Xunit;
using Moq;
using WeatherBots;
using AutoFixture;

namespace BotsProcessTests
{
    public class SunBotTests
    {
        private Fixture _fixture;
        private Mock<IPrintingService> _mockPrintingService;
        private SunBot _sunBot;

        public SunBotTests()
        {
            _fixture = new Fixture();
            _mockPrintingService = new Mock<IPrintingService>();
            _sunBot = _fixture.Build<SunBot>()
                .With(bot => bot.Enabled, true)
                .With(bot => bot.Message, It.IsAny<string>)
                .With(bot => bot.TemperatureThreshold, 0.6m)
                .Create();
            _sunBot.SetPrintingService(_mockPrintingService.Object);
        }

        [Fact]
        public void SunBotProcessWeatherData_WhenTemperatureIsAboveThreshold_ShouldCallPrintingService()
        {
            var mockWeatherData = new Mock<IWeatherData>();
            mockWeatherData.Setup(weatherData => weatherData.Temperature).Returns(0.7m);

            _sunBot.ProcessWeatherData(mockWeatherData.Object);

            _mockPrintingService.Verify(p => p.Print("SunBot activated!"), Times.Once);
            _mockPrintingService.Verify(p => p.Print($"SunBot: \"{_sunBot.Message}\""), Times.Once);
        }

        [Fact]
        public void SunBotProcessWeatherData_WhenTemperatureIsBelowThreshold_ShouldNotCallPrintingService()
        {
            var mockWeatherData = new Mock<IWeatherData>();
            mockWeatherData.Setup(weatherData => weatherData.Temperature).Returns(0.5m);

            _sunBot.ProcessWeatherData(mockWeatherData.Object);

            _mockPrintingService.Verify(p => p.Print(It.IsAny<string>()), Times.Never);
        }
    }
}
