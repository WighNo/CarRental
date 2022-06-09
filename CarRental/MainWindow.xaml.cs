using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CarRental.Model;
using CarRental.View;

namespace CarRental
{
    public partial class MainWindow
    {
        private DatabaseContext _databaseContext;
        
        public MainWindow()
        {
            InitializeComponent();

            _databaseContext = new DatabaseContext();
            _databaseContext.Administrators.Load();
        }

        private void CloseApplication(object sender, RoutedEventArgs e) => FormActions.CloseApplication(sender, e);

        private void HideWindow(object sender, RoutedEventArgs e) => FormActions.HideWindow(sender, e);

        private void MovedBorder(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        
        private void TryLogIn(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;
            
            Administrator administrator = _databaseContext.Administrators.FirstOrDefault(a => a.Login == login && a.Password == password);

            if (administrator is null == true)
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK);
            else
                LogIn(administrator);
        }

        private void LogIn(IUser user)
        {
            Session.Register(user);

            Window openingWindow = new ControlPanel();
            ConfigureNextWindow(openingWindow);

            openingWindow.Show();
            Close();
        }

        private void ConfigureNextWindow(Window window)
        {
            window.Left = Left;
            window.Top = Top;
        }
    }
}