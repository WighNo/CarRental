using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace CarRental.Model
{
    public class Car : INotifyPropertyChanged
    {

        private SolidColorBrush _displayingColor;
        private SolidColorBrush _isBusyColor = new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 60, 60));
        private SolidColorBrush _freeColor = new SolidColorBrush(Colors.CornflowerBlue);
        
        [NotMapped]
        public Brush Busy
        {
            get
            {
                if (Database.Instance.DatabaseContext.Rentals.FirstOrDefault(r =>  r.Car.Id == Id) is null == false)
                    _displayingColor = _isBusyColor;
                else
                    _displayingColor = _freeColor;
                
                return _displayingColor;
            }
        }
        
        public int Id { get; set; }

        private string _model;
        private string _color;

        private string _price;
        private string _gosNumber;

        private string _gearboxType;

        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Model");
            }
        }

        public string GosNumber
        {
            get => _gosNumber;
            set
            {
                _gosNumber = value;
                OnPropertyChanged("GosNumber");
            }
        }

        public string GearboxType
        {
            get => _gearboxType;
            set
            {
                _gearboxType = value;
                OnPropertyChanged("GearboxType");
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
