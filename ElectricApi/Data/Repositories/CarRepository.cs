using ElectricApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ElectricApi.Data.Repositories {
    public class CarRepository : ICarRepository {

        private readonly ElectricContext _context;
        private readonly DbSet<Car> _cars;

        public CarRepository(ElectricContext context) {
            _context = context;
            _cars = context.Cars;
        }

        public void AddCar(Car car) {
            this._cars.Add(car);
        }

        public Car CarById(int carId) {
            return _cars.Include(c=>c.Reviews).FirstOrDefault(c => c.id == carId);
        }

        public Car CarByModel(string model) {
            return _cars.Include(c=>c.Reviews).FirstOrDefault(c => c.Model == model);
        }

        public void DeleteCar(Car car) {
            _cars.Remove(car);
        }

        public IEnumerable<Car> GetAllCars() {
            return _cars.Include(c => c.Reviews).ToList();
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public void UpdateCar(Car car) {
            _cars.Update(car);
        }
    }
}
