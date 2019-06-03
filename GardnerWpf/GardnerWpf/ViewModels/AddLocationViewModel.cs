using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GardnerWpf
{
    public class AddLocationViewModel : INotifyPropertyChanged
    {
        //private Location _location;

        //public Location Location
        //{
        //    get { return _location; }
        //    set
        //    {
        //        _location = value;
        //        RaisePropertyChanged();
        //    }
        //}

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }


        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                RaisePropertyChanged();
            }
        }

        private int _streetNumber;

        public int StreetNumber
        {
            get { return _streetNumber; }
            set
            {
                _streetNumber = value;
                RaisePropertyChanged();
            }
        }

        private int _zipCode;

        public int ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                RaisePropertyChanged();
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _trees;
        public ObservableCollection<string> Trees
        {
            get { return _trees; }
            set
            {
                _trees = value;
                RaisePropertyChanged();
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
