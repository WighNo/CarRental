using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CarRental.Model;

namespace CarRental.View.ControlPanelPages
{
    public partial class AddCar : Page
    {
        public AddCar()
        {
            InitializeComponent();

            Database database = new Database();

            Database.Instance.DatabaseContext.Cars.Load();
            Database.Instance.DatabaseContext.Rentals.Load();

            DataContext = Database.Instance.DatabaseContext.Cars.Local.ToBindingList();
        }
        
        private void Scrolling(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void AddNewCar(object sender, RoutedEventArgs e)
        {
            if (CarModel.Text == "" || CarColor.Text == "" || CarGosNumber.Text == "" || CarGearboxType.Text == "" ||
                PricePerHour.Text == "")
            {
                MessageBox.Show("Введены не все данные", "Ошибка", MessageBoxButton.OK);
                return;
            }

            Car car = new Car
            {
                Model = CarModel.Text,
                Color = CarColor.Text,
                GosNumber = CarGosNumber.Text,
                GearboxType = CarGearboxType.Text,
                Price = PricePerHour.Text,
            };

            DatabaseContext databaseContext = new DatabaseContext();

            databaseContext.Cars.Add(car);
            databaseContext.SaveChanges();

            DataContext = databaseContext.Cars.ToList();

            Console.WriteLine(car.Busy);
        }

        private void RemoveCar(object sender, RoutedEventArgs e)
        {
            if (CarsList.SelectedItem is null == true)
            {
                MessageBox.Show("Автомобиль не выбран", "Ошибка", MessageBoxButton.OK);
                return;
            }

            Car selectedCar = CarsList.SelectedItem as Car;

            Database.RemoveCar(selectedCar);

            DataContext = Database.Instance.DatabaseContext.Cars.Local.ToBindingList();
        }

    }
}