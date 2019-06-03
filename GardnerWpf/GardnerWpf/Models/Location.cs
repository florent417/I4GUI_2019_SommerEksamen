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
    public class Location 
    {
        public Location(int id, string name, string street, int streetNbr, int zipCode, string city)
        {
            this.Id = id;
            this.Name = name;
            this.Street = street;
            this.StreetNumber = streetNbr;
            this.ZipCode = zipCode;
            this.City = city;
        }

        public Location()
        {

        }

        private int _id;
        public int Id
        {
            get { return _id;}
            set
            {
                _id = value;
                //RaisePropertyChanged();
            }
        } 

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                //RaisePropertyChanged();
            }
        }


        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                //RaisePropertyChanged();
            }
        }

        private int _streetNumber;

        public int StreetNumber
        {
            get { return _streetNumber; }
            set
            {
                _streetNumber = value;
                //RaisePropertyChanged();
            }
        }

        private int _zipCode;

        public int ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                //RaisePropertyChanged();
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                //RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _trees = new ObservableCollection<string>();
        public ObservableCollection<string> Trees
        {
            get { return _trees; }
            set
            {
                _trees = value;
                //RaisePropertyChanged();
            }
        }
        
        //#region INotifyPropertyChanged implementation

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void RaisePropertyChanged([CallerMemberName] string property = null)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(property));
        //    }
        //}

        //#endregion
    }
}
