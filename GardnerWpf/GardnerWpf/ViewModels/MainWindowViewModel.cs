using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace GardnerWpf
{
    public class MainWindowViewModel
    {
        // Måske locations.count
        private int _id = 0;
        private string filePath = null;
        public MainWindowViewModel()
        {
            _locations = new ObservableCollection<Location>();
            Debug.WriteLine("Test");
        }

        #region Collections

        private ObservableCollection<Location> _locations;
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                RaisePropertyChanged();
            }
        }

        //private ObservableCollection<string> _trees;

        //public ObservableCollection<string> Trees
        //{
        //    get { return _trees; }
        //    set
        //    {
        //        _trees = value;
        //        RaisePropertyChanged();
        //    }
        //}

        #endregion
        
        #region Current Items

        private Location _currentLocation = null;

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                RaisePropertyChanged();
            }
        }

        private string _sort;

        public string Sort
        {
            get { return _sort;}
            set
            {
                _sort = value;
                RaisePropertyChanged();
            }
        }

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged();
            }
        }


        #endregion



        #region Commands

        #region File Commands
        
        

        #endregion

        ICommand _addLocationCommand;

        public ICommand AddLocationCommand
        {
            get { return _addLocationCommand ?? (_addLocationCommand = new RelayCommand(AddLocationCommandConfirmed)); }

        }

        private void AddLocationCommandConfirmed()
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

        ICommand _addTreeCommand;

        public ICommand AddTreeCommand
        {
            get { return _addTreeCommand ?? (_addTreeCommand = new RelayCommand(AddTreeCommandConfirmed)); }

        }

        private void AddTreeCommandConfirmed()
        {
            var temp = CurrentLocation;
            _locations.Remove(CurrentLocation);
            temp.Trees.Add(Sort + " " + Amount);
            _locations.Add(temp);
            CurrentLocation = Locations.Last();
            Debug.WriteLine(CurrentLocation.Trees.First());
        }

        ICommand _showTreesCommand;

        public ICommand ShowTreesCommand
        {
            get { return _showTreesCommand ?? (_showTreesCommand= new RelayCommand(ShowTreesCommandConfirmed)); }

        }

        private void ShowTreesCommandConfirmed()
        {
            Trees treesWindow = new Trees();
            treesWindow.Owner = Application.Current.MainWindow;
            treesWindow.tVM.Trees = CurrentLocation.Trees;
            Debug.WriteLine("Test");
            treesWindow.ShowDialog();
        }

        #endregion



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
