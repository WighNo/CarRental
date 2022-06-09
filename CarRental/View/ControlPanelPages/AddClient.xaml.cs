using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CarRental.Model;

namespace CarRental.View.ControlPanelPages
{
    public partial class AddClient : Page
    {
        public static event Action<int> OnClientRemove;

        public AddClient()
        {
            InitializeComponent();

            Database database = new Database();
            Database.Instance.DatabaseContext.Clients.Load();
            
            DataContext = Database.Instance.DatabaseContext.Clients.Local.ToBindingList();
        }
        
        private void Scrolling(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            if (NewLastName.Text == ""|| NewFirstName.Text == "" || NewDriverNumber.Text == "" || NewPassportId.Text == "" || NewPassportSeries.Text == "" )
            {
                MessageBox.Show("Введены не все данные", "Ошибка", MessageBoxButton.OK);
                return;
            }

            Client client = new Client
            {
                LastName = NewLastName.Text,
                FirstName = NewFirstName.Text,
                PassportId = NewPassportId.Text,
                PassportSeries = NewPassportSeries.Text,
                DriverNumber = NewDriverNumber.Text,
            };

            DatabaseContext databaseContext = new DatabaseContext();

            databaseContext.Clients.Add(client); 
            databaseContext.SaveChanges();
            
            DataContext = databaseContext.Clients.ToList();
        }

        private void RemoveClient(object sender, RoutedEventArgs e)
        {
            if (ClientsList.SelectedItem is null == true)
            {
                MessageBox.Show("Клиент не выбран", "Ошибка", MessageBoxButton.OK);
                return;
            }

            Client selectedClient = ClientsList.SelectedItem as Client;
            Database.RemoveClient(selectedClient);
                        
            DataContext = Database.Instance.DatabaseContext.Clients.Local.ToBindingList();
        }
    }

}