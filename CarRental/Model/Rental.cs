using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarRental.Model
{
    public class Rental : INotifyPropertyChanged
    {
        private string _startOfRental;
        private string _endOfRental;

        private Administrator _administrator;
        private Client _client;
        private Car _car;
        
        public int Id { get; set; }

        public string StartOfRental 
        {
            get => _startOfRental;
            set
            {
                _startOfRental = value;
                OnPropertyChanged("StartOfRental");
            }
        }
        
        public string EndOfRental
        {
            get => _endOfRental;
            set
            {
                _endOfRental = value;
                OnPropertyChanged("EndOfRental");
            }
        }
        
        public Administrator Administrator 
        {
            get => _administrator;
            set
            {
                _administrator = value;
                OnPropertyChanged("Administrator");
            }
        }
        
        public Car Car
        {
            get => _car;
            set
            {
                _car = value;
                OnPropertyChanged("Car");
            }
        }
        
        public Client Client
        {
            get => _client;
            set
            {
                _client = value;
                OnPropertyChanged("Client");
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