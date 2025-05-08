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
using System.Windows;

namespace NewCarWPFApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICarRepository _carRepository;

        private readonly ITripRepository _tripRepository;
        public Car SelectedCar { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        public ObservableCollection<Trip> Trips { get; set; }
        public ICommand ShowCarWindowCommand { get; set; }
        public ICommand ShowTripWindowCommand { get; set; }
        public ICommand CloseCommand { get; }
        public Action? CloseAction { get; set; }

        public MainViewModel()
        {
            _carRepository = new FileCarRepository("cars.txt");
            _tripRepository = new FileTripRepository("trips.txt");

            Cars = new ObservableCollection<Car>(_carRepository.GetAllCars());
            Trips = new ObservableCollection<Trip>(_tripRepository.GetTripsForCar());

            OnPropertyChanged(nameof(Cars));
            OnPropertyChanged(nameof(Trips));

            ShowCarWindowCommand = new RelayCommand(ShowCarWindow, CanShowWindow);
            ShowTripWindowCommand = new RelayCommand(ShowTripWindow, CanShowWindow);

            CloseCommand = new RelayCommand(_ => CloseAction?.Invoke(), _ => true);
        }

    

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowCarWindow(object obj)
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

            private void ShowTripWindow(object obj)
                {
                    AddTrip addTripWin = new AddTrip();
                    addTripWin.ShowDialog(); // Vent til vindue lukkes

                    // Reload bilerne fra filen bagefter
                    if (SelectedCar == null) return;

                    Trips.Clear();
                    foreach (var trip in _tripRepository.GetTripsForCar(SelectedCar.LicensePlate))
                        {
                             Trips.Add(trip);
                        }
        }

        

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
