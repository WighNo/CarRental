using System.Windows;
using System.Windows.Input;

namespace CarRental
{
    public static class FormActions
    {
        public static void CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public static void HideWindow(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow != null)
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}