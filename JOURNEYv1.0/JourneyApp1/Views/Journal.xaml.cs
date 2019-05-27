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
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class Journal : UserControl
    {
        private ViewModelJournal _journalVM;
        private MainWindow _parent;
        public ViewModelJournal journalVM { get { return _journalVM; } set { _journalVM = value; } }
        public MainWindow parent { get { return _parent; } set { _parent = value; } }
        public Journal()
        {
        }
        public Journal(MainWindow parent)
        {
            this.parent = parent;
            journalVM = new ViewModelJournal(parent.viewModel);
            journalVM.journalName = "TestJournalName";
            journalVM.journalTextString = "Test Journal Text";
            DataContext = journalVM;
            InitializeComponent();
        }
    }
}
