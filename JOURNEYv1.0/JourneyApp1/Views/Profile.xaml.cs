using JourneyApp1.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JourneyApp1.Views
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        private ViewModelProfile _profileVM;
        private MainWindow _parent;
        public ViewModelProfile profileVM { get { return _profileVM; } set { _profileVM = value; } }
        public MainWindow parent { get { return _parent; } set { _parent = value; } }
        public Profile()
        {
        }
        public Profile(MainWindow parent)
        {
            this.parent = parent;
            profileVM = new ViewModelProfile(parent.viewModel);
            InitializeComponent();
        }
    }
}
