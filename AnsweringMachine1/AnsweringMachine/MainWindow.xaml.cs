using AnsweringMachine.Logic;
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

namespace AnsweringMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Machine TheMachine;
        public MainWindow()
        {
            TheMachine = new Machine();
            InitializeComponent();
            DataContext = TheMachine;
        }
        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        public void Window_Operation(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content.ToString())
            {
                case "-":
                    WindowState = WindowState.Minimized;
                    return;
                case "+":
                    return;
                case "x":
                    Application.Current.Shutdown();
                    return;
                case "Submit Question":
                    TheMachine.GenerateNew();
                    DataContext = TheMachine;
                    return;
                default:
                    return;
            }
        }

    }
}
