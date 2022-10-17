using AutoFixture;
using AutoFixture.Xunit2;
using BusinessLogic;
using Common;
using Domain;
using Infrastucture.HttpLayer;
using Infrastyructure.DbLayer;
using Microsoft.Extensions.Logging;
using Moq;

namespace BusinessLogicUnitTests
{
    public class WeatherServiceTests
    {
        private readonly Mock<IWeatherHttpRepository> _httpRepositoryMock;
        private readonly Mock<IWeatherDbRepository> _dbRepositoryMock;
        private readonly Mock<ILogger<WeatherService>> _loggerMock;
        private readonly WeatherService _sut;
        private readonly Fixture _fixture;

        public WeatherServiceTests()
        { 
        _fixture = new Fixture();
            _fixture.Customizations.Add(new WeatherSpecimentBuilder());
        _httpRepositoryMock = new Mock<IWeatherHttpRepository>();
        _dbRepositoryMock = new Mock<IWeatherDbRepository>();
        _loggerMock = new Mock<ILogger<WeatherService>>();
        _sut = new WeatherService(_httpRepositoryMock.Object, _dbRepositoryMock.Object, _loggerMock.Object);
        }

        [Theory, AutoData]
        public async void ReadAndSaveWeatherDataAsync_WhenIsCalledWithCity_GetsDataFromHttpRepositoryAndInsertsToDbRepository(Weather weather)
        {
            
            _httpRepositoryMock.Setup(h => h.GetWeatherDataAsync(It.IsAny<string>()))
                .ReturnsAsync(weather);

            var result = await _sut.ReadAndSaveWeatherDataAsync("Kaunas");

            Assert.Equal(weather, result);
            _httpRepositoryMock.Verify(h=>h.GetWeatherDataAsync("Kaunas"), Times.Once());   
            _dbRepositoryMock.Verify(d=>d.InsertAsync(weather), Times.Once());   

        }
    }
}