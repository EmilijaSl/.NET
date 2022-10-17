using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public interface IDatabaseRepository
    {
        List<Car> GetAllCars();
        List<Car> GetCarsByColor(string color);
        void CreateCar(Car car);
        Car GetCarById(int id);
        void DeleteCar(int id);
        void UpdateCar(Car car);
        void Commit();
        void Add(Accaunt accaunt);
        Task CommitAsync();
        Task<Accaunt> GetAccauntAsync(string username);
        Task UpdateRoleAsync(Accaunt accaunt);
        Accaunt GetAccauntById(int id);


    }
}
