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
using JourneyApp1.ViewModels;

namespace JourneyApp1.Views
{
    /// <summary>
    /// Interaction logic for Default.xaml
    /// </summary>
    public partial class Default : UserControl
    {
        private ViewModelBase _defaultVM;
        private MainWindow _parent;
        public ViewModelBase defaultVM { get { return _defaultVM; } set { _defaultVM = value; } }
        public MainWindow parent { get { return _parent; } set { _parent = value; } }
        public Default()
        { }
        public Default(MainWindow parent)
        {
            this.parent = parent;
            defaultVM = new ViewModelBase(parent.viewModel);
            InitializeComponent();
        }

        private void ChangeView(object sender, RoutedEventArgs e)
        {
            parent.ChangePage(sender, e);
        }
    }
}
