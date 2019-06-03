using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GardnerWpf
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            _locations = new ObservableCollection<Location>();
            Debug.WriteLine("Test");
        }

        private ObservableCollection<Location> _locations;

        private int _id = 0;
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                RaisePropertyChanged();
            }
        }

        private Location _currentLocation = null;

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation= value; 
                RaisePropertyChanged();
            }
        }

        ICommand _addLocationCommand;

        public ICommand AddLocationCommand
        {
            get { return _addLocationCommand ?? (_addLocationCommand = new RelayCommand(AddModelCommandConfirmed)); }

        }

        private void AddModelCommandConfirmed()
        {
            AddLocation addLocationWindow = new AddLocation();
            addLocationWindow.Owner = Application.Current.MainWindow;
            Debug.WriteLine("Test");
            if (addLocationWindow.ShowDialog() == true)
            {
                ++_id;
                Debug.WriteLine(addLocationWindow.aLVM.Name);
                var location = new Location()
                {
                    Id = _id,

                    //Name = addLocationWindow.aLVM.Location.Name,
                    //Street = addLocationWindow.aLVM.Location.Street,
                    //StreetNumber = addLocationWindow.aLVM.Location.StreetNumber,
                    //ZipCode = addLocationWindow.aLVM.Location.ZipCode,
                    //City = addLocationWindow.aLVM.Location.City

                    Name = addLocationWindow.aLVM.Name,
                    Street = addLocationWindow.aLVM.Street,
                    StreetNumber = addLocationWindow.aLVM.StreetNumber,
                    ZipCode = addLocationWindow.aLVM.ZipCode,
                    City = addLocationWindow.aLVM.City
                };

                _locations.Add(location);
                Debug.WriteLine(_locations[0].Name);
                Debug.WriteLine(_locations[0].Name.Length);
            };
        }

        //public ICommand AddModelCommand
        //{
        //    get
        //    {
        //        return _addModelCommand ?? (_addModelCommand = new DelegateCommand(() =>
        //        {
        //            AddModel addModelWindow = new AddModel();
        //            addModelWindow.Owner = Application.Current.MainWindow;
        //            Debug.WriteLine("Test");
        //            if (addModelWindow.ShowDialog() == true)
        //            {
        //                var model = new Model()
        //                {
        //                    Name = addModelWindow.aVM.Name,
        //                    PhoneNr = addModelWindow.aVM.PhoneNr,
        //                    Adress = addModelWindow.aVM.Adress,
        //                    Height = addModelWindow.aVM.Height,
        //                    Weight = addModelWindow.aVM.Weight,
        //                    HairColor = addModelWindow.aVM.HairColor,
        //                    Comment = addModelWindow.aVM.Comment
        //                };

        //                _models.Add(model);
        //                Debug.WriteLine(_models[0].Name);
        //            }
        //        }));
        //    }
        //}

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
    }
}
