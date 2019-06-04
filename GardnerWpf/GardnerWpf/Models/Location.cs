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
            }
        } 

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }


        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
            }
        }

        private int _streetNumber;

        public int StreetNumber
        {
            get { return _streetNumber; }
            set
            {
                _streetNumber = value;
            }
        }

        private int _zipCode;

        public int ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
            }
        }

        private ObservableCollection<string> _trees = new ObservableCollection<string>();
        public ObservableCollection<string> Trees
        {
            get { return _trees; }
            set
            {
                _trees = value;
            }
        }
    }
}
