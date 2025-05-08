using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewCarWPFApp.Core;
using NewCarWPFApp.Models;
using System.Windows.Input;
using System.ComponentModel;
using NewCarWPFApp.Repositories;

namespace NewCarWPFApp.ViewModels
{
    public class AddCarViewModel : INotifyPropertyChanged
        {
        private readonly ICarRepository _carRepository = new FileCarRepository("cars.txt");
        public ICommand AddCarCommand { get; set; }

        private string? licensePlate;
        public string? LicensePlate
        {
            get => licensePlate;
            set
            {
                licensePlate = value;
                OnPropertyChanged(nameof(licensePlate));
            }
        }
        private string? model;
        public string? Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged(nameof(model));
            }
        }

            public AddCarViewModel()
            {
                AddCarCommand = new RelayCommand(AddCar, CanAddCar);
            }

            private bool CanAddCar(object obj)
            {
                return true;
            }

            private void AddCar(object obj)
            {
                _carRepository.AddCar(new Car
                {
                    LicensePlate = LicensePlate,
                    Model = Model                    
                });

            // Nulstil inputfelter:
            LicensePlate = string.Empty;
            Model = string.Empty;

            }

            //  INotifyPropertyChanged implementering
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
        }
    }

