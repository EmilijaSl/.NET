using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        List<Car> GetCarsByColor(string color);
        int CreateCar(Car car);
        Car GetCarById(int id);
        void DeleteCar(int id);
        void UpdateCar(Car car);
    }
}
