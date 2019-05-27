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
    /// Interaction logic for Journals.xaml
    /// </summary>
    public partial class Journals : UserControl
    {
        private ViewModelJournals _journalsVM;
        private MainWindow _parent;
        public ViewModelJournals journalsVM { get { return _journalsVM; } set { _journalsVM = value; } }
        public MainWindow parent { get { return _parent; } set { _parent = value; } }
        public Journals()
        {
        }
        public Journals(MainWindow parent)
        {
            this.parent = parent;
            journalsVM = new ViewModelJournals(parent.viewModel);
            journalsVM.tempJournal = new Journal(parent);
            DataContext = journalsVM;
            InitializeComponent();
        }
    }
}
