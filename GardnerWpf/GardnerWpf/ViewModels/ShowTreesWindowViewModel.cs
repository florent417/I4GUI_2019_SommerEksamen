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
    public class ShowTreesWindowViewModel : INotifyPropertyChanged
    {

        public ShowTreesWindowViewModel()
        {
            _trees = new ObservableCollection<string>();
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
