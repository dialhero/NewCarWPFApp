using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewCarWPFApp.Models;

namespace NewCarWPFApp.Repositories
{
    public interface ICarRepository
    {
        public IEnumerable<Car> GetAllCars();

        public Car? GetCar(string licensePlate);

        public void AddCar (Car car);

        public void UpdateCar(Car car);

        public void DeleteCar (string licensePlate);

    }
}
