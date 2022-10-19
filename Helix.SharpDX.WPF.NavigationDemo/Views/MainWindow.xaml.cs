using System.Windows;

using Helix.SharpDX.WPF.NavigationDemo.Services;
using Helix.SharpDX.WPF.NavigationDemo.ViewModels;
using Helix.SharpDX.WPF.NavigationDemo.Views.Pages;

namespace Helix.SharpDX.WPF.NavigationDemo.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel, NavigationService navigationService)
    {
        InitializeComponent();

        DataContext = viewModel;

        navigationService.NavigationControl = NavigationView;
        navigationService.Navigate(typeof(AboutPage));
    }
}
