using AutoFixture;
using BusinessLogic;
using DataAcces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicUnitTests
{
    public class CarServiceTests
    {
        private readonly Mock<IDatabaseRepository> _databaseRepositoryMock;
        private readonly CarService _sut;
        private readonly Fixture _fixture;

        public CarServiceTests()
        { 
        _databaseRepositoryMock = new Mock<IDatabaseRepository>();
            _fixture = new Fixture();
            _sut = new CarService(_databaseRepositoryMock.Object);
        }

        [Fact]
        public void GetAllCars()
        {
            var cars = _fixture.Create<List <Car>>();
            _databaseRepositoryMock.Setup(c=>c.GetAllCars()).Returns(cars);

            var result = _sut.GetAllCars();
            Assert.Equal(cars, result);
       
        }


    }
}
