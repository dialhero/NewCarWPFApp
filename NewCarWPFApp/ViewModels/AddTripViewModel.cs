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
using System.Collections.ObjectModel;
using System.Security.Permissions;

namespace NewCarWPFApp.ViewModels
{
    public class AddTripViewModel : INotifyPropertyChanged
    {
        private readonly ITripRepository _tripRepository;
        public ObservableCollection<Car> Cars { get; set; }
        public Car SelectedCar { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public double Distance { get; set; }

        public ICommand SaveCommand { get; }

        public event Action<Trip>? TripAdded;

        public AddTripViewModel(ITripRepository tripRepository, ObservableCollection<Car> cars)
        {
            _tripRepository = tripRepository;
            Cars = cars;
            SaveCommand = new RelayCommand(AddTrip, CanAddTrip);
        }

        private bool CanAddTrip(object _) => SelectedCar != null && Distance > 0 && StartDate <= EndDate;

        private void AddTrip(object _)
        {
            var newTrip = new Trip
            {
                LicensePlate = SelectedCar.LicensePlate,
                StartDate = StartDate,
                EndDate = EndDate,
                Distance = Distance
            };
            _tripRepository.AddTrip(newTrip);
            TripAdded?.Invoke(newTrip); //Giv MainViewModel besked

            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Distance = 0;
            OnPropertyChanged(nameof(StartDate));
            OnPropertyChanged(nameof(EndDate));
            OnPropertyChanged(nameof(Distance));

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)=>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
