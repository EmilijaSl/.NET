using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class DatabaseRepository:IDatabaseRepository
    {
        private readonly ApplicationDbContext _context;
        
        public DatabaseRepository(ApplicationDbContext context)
        {
            _context = context;
          
        }

        public void Add(Accaunt accaunt)
        {
            _context.Add(accaunt);
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Accaunt> GetAccauntAsync(string username)
        {
            return await _context.Accaunts.FirstOrDefaultAsync(a => a.Username == username);
        }
        public List<Car> GetAllCars()
        { 
        return _context.Cars.ToList();
        }

        public List<Car> GetCarsByColor(string color)
        { 
        return _context.Cars.Where(x => x.CarColor == color).ToList(); //Ienumerable dali pridedame jeigu norime grazintis ne viena o kelias masinas
        }

        public void CreateCar(Car car)
        {
          
            _context.Add(car);
        }
        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteCar(int id)
        { 
        var carToRemove = GetCarById(id);
            _context.Cars.Remove(carToRemove);
        }
        public void UpdateCar(Car car)
        {
            var carFromDb = GetCarById(car.Id);
            carFromDb.CarModel = car.CarModel;
            carFromDb.CarColor = car.CarColor;

        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public Accaunt GetAccauntById(int id)
        {
            return _context.Accaunts.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateRoleAsync(Accaunt accaunt)
        {
            var caunt = GetAccauntById(accaunt.Id);
            caunt.Role = accaunt.Role;
            
        }
    }
}
