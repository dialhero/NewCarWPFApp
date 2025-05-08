using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NewCarWPFApp.Core;
using NewCarWPFApp.Models;
using NewCarWPFApp.Repositories;
using NewCarWPFApp.ViewModels;
using NewCarWPFApp.Views;
using System.ComponentModel;

namespace NewCarWPFApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICarRepository _carRepository;
        public ObservableCollection<Car> Cars { get; set; }
        public ObservableCollection<Trip> Trips { get; set; }
        public ICommand ShowWindowCommand { get; set; }



        public MainViewModel()
        {
            _carRepository = new FileCarRepository("cars.txt");
            Cars = new ObservableCollection<Car>(_carRepository.GetAllCars());
            OnPropertyChanged(nameof(Cars));
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            AddCar addCarWin = new AddCar();
            addCarWin.ShowDialog(); // Vent til vindue lukkes

            // Reload bilerne fra filen bagefter
            Cars.Clear();
            foreach (var car in _carRepository.GetAllCars())
            {
                Cars.Add(car);
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
