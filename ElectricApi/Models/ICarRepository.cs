using System.Collections.Generic;

namespace ElectricApi.Models {
    public interface ICarRepository {
        Car CarById(int carId);
        Car CarByModel(string model);
        IEnumerable<Car> GetAllCars();
        void AddCar(Car car);
        void DeleteCar(Car car);
        void UpdateCar(Car car);
        void SaveChanges();
    }
}
