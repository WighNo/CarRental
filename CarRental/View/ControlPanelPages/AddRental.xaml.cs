using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CarRental.Model;

namespace CarRental.View.ControlPanelPages
{
    public partial class AddRental : Page
    {
        public AddRental()
        {
            InitializeComponent();

            Database database = new Database();
            LoadContent();

            UpdateDataContext();
        }

        private void LoadContent()
        {
            Database database = new Database();

            Database.Instance.DatabaseContext.Cars.Load();
            Database.Instance.DatabaseContext.Clients.Load();
            Database.Instance.DatabaseContext.Rentals.Load();
        }
        
        private void UpdateDataContext()
        {
            CarsList.DataContext = Database.Instance.DatabaseContext.Cars.ToList();
            ClientsList.DataContext = Database.Instance.DatabaseContext.Clients.ToList();
            RentalsList.DataContext = Database.Instance.DatabaseContext.Rentals.ToList();
            
            CarsList.SelectedItem = null;
            ClientsList.SelectedItem = null;
            RentalsList.SelectedItem = null;
        }
        
        private void AddNewRental(object sender, RoutedEventArgs e)
        {
            if(ValidateAdding() == false)
                return;

            Rental rental = new Rental();

            rental.StartOfRental = StartDate.Text;
            rental.EndOfRental = EndDate.Text;
            
            rental.Administrator = Database.Instance.DatabaseContext.Administrators.First(a => a.Id == Session.User.Id);

            Client selectedClient = ClientsList.SelectedItem as Client;
            rental.Client = Database.Instance.DatabaseContext.Clients.First(c => c.Id == selectedClient.Id);

            Car selectedCar = CarsList.SelectedItem as Car;
            rental.Car = Database.Instance.DatabaseContext.Cars.First(c => c.Id == selectedCar.Id);

            Database.Instance.DatabaseContext.Rentals.Add(rental);
            Database.Instance.DatabaseContext.SaveChanges();

            UpdateDataContext();
        }

        private bool ValidateAdding()
        {
            if (ClientsList.SelectedItem is null == true || CarsList.SelectedItem is null == true)
            {
                MessageBox.Show("Клиент или автомобиль не выбраны", "Ошибка", MessageBoxButton.OK);
                return false;
            }

            if (StartDate.Text == "" || EndDate.Text == "")
            {
                MessageBox.Show("Не заполнены даты", "Ошибка", MessageBoxButton.OK);
                return false;
            }

            Car selectedCar = CarsList.SelectedItem as Car;
            Car car = Database.Instance.DatabaseContext.Cars.First(c => c.Id == selectedCar.Id);
            
            if (Database.Instance.DatabaseContext.Rentals.FirstOrDefault(r => r.Car.Id == car.Id) is null == false)
            {
                MessageBox.Show("Выбранная машина уже в прокате", "Ошибка", MessageBoxButton.OK);
                return false;
            }
            
            
            return true;
        }
        
        private void RemoveRental(object sender, RoutedEventArgs e)
        {
            if (RentalsList.SelectedItem is null == true)
            {
                MessageBox.Show("Не выбран элемент", "Ошибка", MessageBoxButton.OK);
                return;
            }

            Rental selectedRental = RentalsList.SelectedItem as Rental;

            Database.Instance.DatabaseContext.Rentals.Remove(
                Database.Instance.DatabaseContext.Rentals.First(c => c.Id == selectedRental.Id));

            Database.Instance.DatabaseContext.SaveChanges();
            
            UpdateDataContext();
        }
        
        private void Scrolling(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        
    }
}