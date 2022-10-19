using Helix.SharpDX.WPF.NavigationDemo.ViewModels;
using System.Windows.Controls;

namespace Helix.SharpDX.WPF.NavigationDemo.Views.Pages;

/// <summary>
/// Interaction logic for AboutPage.xaml
/// </summary>
public partial class AboutPage : Page
{
    public AboutPage(AboutViewModel viewModel)
    {
        System.Diagnostics.Trace.WriteLine("==== [AboutPage] Constructor ====");

        InitializeComponent();
        DataContext = viewModel;

        Unloaded += OnUnload;
    }

    ~AboutPage()
    {
        System.Diagnostics.Trace.WriteLine("==== [AboutPage] Finalizer ====");
    }

    private void OnUnload(object sender, System.Windows.RoutedEventArgs e)
    {
        System.Diagnostics.Trace.WriteLine("==== [AboutPage] Unloaded ====");
    }

}
