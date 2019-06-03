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
        private string fileName = null;
        private string searchTerm = null;

        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                searchTerm = value;
                RaisePropertyChanged();
            }
        }

        public string FileName
        {
            get { return fileName;}
            set
            {
                fileName = value;
                RaisePropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            _locations = new ObservableCollection<Location>();
            _tempLocations = new ObservableCollection<Location>();
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

        private ObservableCollection<Location> _tempLocations;
        public ObservableCollection<Location> TempLocations
        {
            get { return _tempLocations; }
            set
            {
                _tempLocations = value;
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

        ICommand _saveFileCommand;

        public ICommand SaveFileCommand
        {
            get { return _saveFileCommand ?? (_saveFileCommand = new RelayCommand(SaveFileCommandConfirmed)); }

        }

        private void SaveFileCommandConfirmed()
        {
            if (fileName != "")
            {
                Repository.SaveFile(fileName, _locations);
            }

            else
            {
                MessageBox.Show("Write a file name");
            }
        }

        ICommand _openFileCommand;

        public ICommand OpenFileCommand
        {
            get
            {
                Debug.WriteLine(fileName);
                return _saveFileCommand ?? (_saveFileCommand = new RelayCommand(OpenFileCommandConfirmed));
            }

        }

        private void OpenFileCommandConfirmed()
        {
            Debug.WriteLine(fileName);
            if (fileName != "")
            {
                Repository.ReadFile(fileName, out _locations);
            }
            
            else
            {
                MessageBox.Show("Write a file name");
            }
            Debug.WriteLine(_locations.First().Name);
        }

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
            treesWindow.Show();
        }

        ICommand _searchCommand;

        public ICommand SearchCommand
        {
            get { return _searchCommand ?? (_searchCommand = new RelayCommand(SearchCommandConfirmed)); }

        }

        private void SearchCommandConfirmed()
        {
            if (searchTerm == "")
            {
                _locations.Clear();
                foreach (var tempLocation in _tempLocations)
                {
                    _locations.Add(tempLocation);
                }
                _tempLocations.Clear();
            }
            else
            {
                Debug.WriteLine("testing search");
                _tempLocations.Clear();
                foreach (var location in Locations)
                {
                    if (location.Name == searchTerm)
                    {
                        _tempLocations.Add(location);
                    }
                }
                Debug.WriteLine("testing search");

                var temp1 = new ObservableCollection<Location>();
                foreach (var location in _locations)
                {
                    temp1.Add(location);
                }

                _locations.Clear();

                foreach (var tempLocation in _tempLocations)
                {
                    _locations.Add(tempLocation);
                }

                _tempLocations.Clear();

                foreach (var location in temp1)
                {
                    _tempLocations.Add(location);
                }
                Debug.WriteLine("testing search");
            }
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
