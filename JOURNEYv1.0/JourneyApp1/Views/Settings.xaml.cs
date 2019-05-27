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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        private ViewModelSettings _settingsVM;
        private MainWindow _parent;
        public ViewModelSettings settingsVM { get { return _settingsVM; } set { _settingsVM = value; } }
        public MainWindow parent { get { return _parent; } set { _parent = value; } }
        public Settings()
        {
        }
        public Settings(MainWindow parent)
        {
            this.parent = parent;
            settingsVM = new ViewModelSettings(parent.viewModel);
            InitializeComponent();
        }
    }
}
