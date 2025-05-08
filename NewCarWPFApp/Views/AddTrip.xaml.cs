using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NewCarWPFApp.Models;
using NewCarWPFApp.Repositories;
using NewCarWPFApp.ViewModels;


namespace NewCarWPFApp.Views
{
    /// <summary>
    /// Interaction logic for AddTrip.xaml
    /// </summary>
    public partial class AddTrip : Window
    {
        public AddTrip(ITripRepository tripRepo, ObservableCollection<Car> cars, Action<Trip>? onTripAdded = null)
        {
            InitializeComponent();
            AddTripViewModel addTripViewModel = new AddTripViewModel(tripRepo, cars);
            addTripViewModel.TripAdded += onTripAdded;
            DataContext = addTripViewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // eller anden funktionalitet
        }
    }
}
