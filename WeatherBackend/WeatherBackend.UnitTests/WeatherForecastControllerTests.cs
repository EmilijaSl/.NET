using AutoFixture;
using AutoFixture.Xunit2;
using BusinessLogic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WeatherBackend.Controllers;

namespace WeatherBackend.UnitTests
{
    public class WeatherForecastControllerTests
    {
        private Mock<ILogger<WeatherForecastController>> _loggerMock; //preoperciai
        private Mock<IWeatherService> _weatherServiceMock;
        private WeatherForecastController _sut;
        private IFixture _fixture;
        public WeatherForecastControllerTests()
        {
            _loggerMock = new Mock<ILogger<WeatherForecastController>>();
            _weatherServiceMock = new Mock<IWeatherService>();
            _sut = new WeatherForecastController(_loggerMock.Object, _weatherServiceMock.Object);
            _fixture = new Fixture();

        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Get_WhenCityIsInvalid_ReturnsBadRequest(string city) 
        {
            var result = (await _sut.Get(city));
            var resultAsBadRequest = result.Result as BadRequestObjectResult;

            Assert.Equal(400, resultAsBadRequest.StatusCode);
        }
        [Fact]
        public async Task Get_WhenServiceThworsNullReferenceExeption_ReturnsInternalServerError()
        { 
        _weatherServiceMock.Setup(
            w=>w.ReadAndSaveWeatherDataAsync(It.IsAny<string>()))
                .ThrowsAsync(new NullReferenceException());

            var result = (await _sut.Get("Vilnius"));
            var resultAsStatusCodeResult = result.Result as StatusCodeResult;

            Assert.Equal(500, resultAsStatusCodeResult.StatusCode);
            _weatherServiceMock.Verify(w => w.ReadAndSaveWeatherDataAsync("Vilnius"), Times.Once()); //mockas paverifyina kad sitas metodas su situ parametru buvo viena kart iskviestas sitame teste
        }

        [Theory, AutoData]
        public async Task Get_WhenServiceReturnsWeatherData_ReturnsOkWithData(Weather weather)
        {
            //var weather = _fixture.Create<Weather>();
           
            _weatherServiceMock.Setup(w => w.ReadAndSaveWeatherDataAsync("Vilnius")).ReturnsAsync(weather);
            var result = await _sut.Get("Vilnius");
            var resultAsOkObjectResult = result.Result as OkObjectResult;

            Assert.Equal(200, resultAsOkObjectResult.StatusCode);
            Assert.Equal(weather, resultAsOkObjectResult.Value);
        }
    } }