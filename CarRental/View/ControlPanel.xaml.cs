using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using CarRental.View.ControlPanelPages;

namespace CarRental.View
{
    public partial class ControlPanel : Window
    {
        public ControlPanel()
        {
            InitializeComponent();
            
            UsernameLabel.Content = Session.User.Username;

            OpeningAddCarPage(null, null);
        }
        
        private void MovedBorder(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        
        private void CloseApplication(object sender, RoutedEventArgs e) => FormActions.CloseApplication(sender, e);

        private void HideWindow(object sender, RoutedEventArgs e) => FormActions.HideWindow(sender, e);

        private void OpeningAddCarPage(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddCar();
            ChangeBarItemColor(0);
        }

        private void OpeningAddClientPage(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddClient();
            ChangeBarItemColor(1);
        }

        private void OpeningAddRentalPage(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddRental();
            ChangeBarItemColor(2);
        }

        private void ChangeBarItemColor(int methodIndex)
        {
            switch (methodIndex)
            {
                case 0:
                    IndexZero.Foreground = Brushes.White;
                    IndexOne.Foreground = Brushes.Gray;
                    IndexTwo.Foreground = Brushes.Gray;
                    break;
                
                case 1:
                    IndexZero.Foreground = Brushes.Gray;
                    IndexOne.Foreground = Brushes.White;
                    IndexTwo.Foreground = Brushes.Gray;
                    break;
                
                case 2:
                    IndexZero.Foreground = Brushes.Gray;
                    IndexOne.Foreground = Brushes.Gray;
                    IndexTwo.Foreground = Brushes.White;
                    break;
            }
        }
    }
}