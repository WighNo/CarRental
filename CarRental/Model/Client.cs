using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarRental.Model
{
    public class Client : INotifyPropertyChanged
    {
        public  int Id { get; set; }

        private string _firstName;
        private string _lastName;
        private string _passportSeries;
        private string _passportId;
        private string _driverNumber;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        
        public string LastName 
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string PassportSeries 
        {
            get => _passportSeries;
            set
            {
                _passportSeries = value;
                OnPropertyChanged("PassportSeries");
            }
        }

        public string PassportId
        {
            get => _passportId;
            set
            {
                _passportId = value;
                OnPropertyChanged("PassportId");
            }
        }

        
        public string DriverNumber
        {
            get => _driverNumber;
            set
            {
                _driverNumber = value;
                OnPropertyChanged("DriverNumber");
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}