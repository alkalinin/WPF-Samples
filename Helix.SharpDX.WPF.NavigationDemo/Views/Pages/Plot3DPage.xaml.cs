using Helix.SharpDX.WPF.NavigationDemo.ViewModels;
using System;
using System.Windows.Controls;

namespace Helix.SharpDX.WPF.NavigationDemo.Views.Pages;

/// <summary>
/// Interaction logic for Plot3DPage.xaml
/// </summary>
public partial class Plot3DPage : Page
{
    public Plot3DPage(Plot3DViewModel viewModel)
    {
        System.Diagnostics.Trace.WriteLine("==== [Plot3DPage] Constructor ====");

        InitializeComponent();
        DataContext = viewModel;

        Unloaded += OnUnload;
    }

    private void OnUnload(object sender, System.Windows.RoutedEventArgs e)
    {
        System.Diagnostics.Trace.WriteLine("==== [Plot3DPage] Unloaded ====");

        // Clean resources,
        // <see href="https://github.com/helix-toolkit/helix-toolkit/issues/1185">HelixToolkit GitHub</see>
        (DataContext as IDisposable)?.Dispose();
        view3D.DataContext = null;
        //view3D.EffectsManager = null;
        //view3D.Items.Clear();
        //view3D.DataContext = null;
        //view3D.Dispose();
        //view3D = null;
        //view3D.Detach();

        //GC.Collect(2, GCCollectionMode.Forced);
        //GC.Collect(2, GCCollectionMode.Forced);
        //GC.WaitForFullGCComplete();
    }

    ~Plot3DPage()
    {
        System.Diagnostics.Trace.WriteLine("==== [Plot3DPage] Finalizer ====");
    }
}
