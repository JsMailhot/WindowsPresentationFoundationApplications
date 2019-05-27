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
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : UserControl
    {
        private ViewModelAbout _aboutVM;
        private MainWindow _parent;
        public ViewModelAbout aboutVM { get { return _aboutVM; } set { _aboutVM = value; } }
        public MainWindow parent { get { return _parent; } set { _parent = value; } }
        public About()
        {
        }
        public About(MainWindow parent)
        {
            this.parent = parent;
            aboutVM = new ViewModelAbout(parent.viewModel);
            InitializeComponent();
        }
    }
}
