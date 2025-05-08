using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCarWPFApp.Models
{
    public class CarManager
    {
        public static ObservableCollection<Car> _DatabaseCar = new ObservableCollection<Car>() { new Car() { LicensePlate = "AB123456", Model = "Tesla" }, new Car { LicensePlate = "FR23456", Model = "Ford" }, new Car { LicensePlate = "QW25896", Model = "Nissan" } };
        
        public static ObservableCollection<Car> GetCars() 
        { 
            return _DatabaseCar; 
        }

        public static void AddCar (Car car)
        { 
            _DatabaseCar.Add(car); 
        }
    }
}
