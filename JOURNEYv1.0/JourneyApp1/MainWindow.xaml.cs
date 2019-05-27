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
using JourneyApp1.Views;
using JourneyApp1.ViewModels;
using JourneyApp1.Properties;

namespace JourneyApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModelBase viewModel;
        public MainWindow()
        {
            viewModel = new ViewModelBase();
            viewModel.title = "Journey App";
            DataContext = viewModel;
            InitializeComponent();
            View.Content = new Default(this);
        }

        public void Login(object sender, RoutedEventArgs e)
        {
            viewModel.ToggleValidateUserVisibility();
            if ((sender as Button).Content.ToString() == "Validate")
            {
            }
            else
            {
            }
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
                case ">":
                    (sender as Button).Content = "<";
                    ViewsPanel.Visibility = Visibility.Visible;
                    return;
                case "<":
                    (sender as Button).Content = ">";
                    ViewsPanel.Visibility = Visibility.Collapsed;
                    return;
                default:
                    return;
            }
        }

        public void ChangePage(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content.ToString())
            {
                case "Profile":
                case "Profile View":
                    if (viewModel.title != "Journey App | Profile")
                    {
                        Profile newView = new Profile(this);
                        viewModel = newView.profileVM;
                        View.Content = newView;
                    }
                    else if (viewModel.title != "Journey App")
                    {
                        Default newView = new Default(this);
                        viewModel = newView.defaultVM;
                        View.Content = newView;
                    }
                    DataContext = viewModel;
                    return;
                case "Journal":
                case "Journal View":
                    if (viewModel.title != "Journey App | Journal")
                    {
                        Journal newView = new Journal(this);
                        viewModel = newView.journalVM;
                        View.Content = newView;
                    }
                    else if (viewModel.title != "Journey App")
                    {
                        Default newView = new Default(this);
                        viewModel = newView.defaultVM;
                        View.Content = newView;
                    }
                    DataContext = viewModel;
                    return;
                case "Journals":
                case "Journals View":
                    if (viewModel.title != "Journey App | Journals")
                    {
                        Journals newView = new Journals(this);
                        viewModel = newView.journalsVM;
                        View.Content = newView;
                    }
                    else if (viewModel.title != "Journey App")
                    {
                        Default newView = new Default(this);
                        viewModel = newView.defaultVM;
                        View.Content = newView;
                    }
                    DataContext = viewModel;
                    return;
                case "Settings":
                case "Settings View":
                    if (viewModel.title != "Journey App | Settings")
                    {
                        Views.Settings newView = new Views.Settings(this);
                        viewModel = newView.settingsVM;
                        View.Content = newView;
                    }
                    else if (viewModel.title != "Journey App")
                    {
                        Default newView = new Default(this);
                        viewModel = newView.defaultVM;
                        View.Content = newView;
                    }
                    DataContext = viewModel;
                    return;
                case "About":
                case "About View":
                    if (viewModel.title != "Journey App | About")
                    {
                        About newView = new About(this);
                        viewModel = newView.aboutVM;
                        View.Content = newView;
                    }
                    else if (viewModel.title != "Journey App")
                    {
                        Default newView = new Default(this);
                        viewModel = newView.defaultVM;
                        View.Content = newView;
                    }
                    DataContext = viewModel;
                    return;
                case "Default":
                case "Default View":
                    if (viewModel.title != "Journey App")
                    {
                        Default newView = new Default(this);
                        viewModel = newView.defaultVM;
                        View.Content = newView;
                    }
                    DataContext = viewModel;
                    return;
                default:
                    if (viewModel.title != "Journey App")
                    {
                        Default newView = new Default(this);
                        viewModel = newView.defaultVM;
                        View.Content = newView;
                    }
                    DataContext = viewModel;
                    return;
            }
        }
    }
}
