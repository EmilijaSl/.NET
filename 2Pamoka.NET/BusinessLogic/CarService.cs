using DataAcces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CarService : ICarService
    {
        private readonly IDatabaseRepository _databaseRepository;
        public CarService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public List<Car> GetAllCars()
        {
            return _databaseRepository.GetAllCars();
        }
        public List<Car> GetCarsByColor(string color)
        {
            return _databaseRepository.GetCarsByColor(color);
        }
        public int CreateCar(Car car)
        {
            _databaseRepository.CreateCar(car);
            _databaseRepository.Commit();

            return car.Id;
        }
        public Car GetCarById(int id)
        {
            return _databaseRepository.GetCarById(id);
        }

        public void DeleteCar(int id)
        { 
        _databaseRepository.DeleteCar(id);
            _databaseRepository.Commit();
        }
        public void UpdateCar(Car car)
        {
            var carFromDb = _databaseRepository.GetCarById(car.Id);
            if (carFromDb == null)
            {
                throw new ArgumentException($"Couldn't find car by Id {car.Id}");
            }
            _databaseRepository.UpdateCar(car);
            _databaseRepository.Commit();
        }

    }
}
