using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GardnerWpf
{
    /// <summary>
    /// Interaction logic for Trees.xaml
    /// </summary>
    public partial class Trees : Window
    {
        public ShowTreesWindowViewModel tVM = new ShowTreesWindowViewModel();
        public Trees()
        {
            InitializeComponent();
            this.DataContext = tVM;
        }
    }
}
