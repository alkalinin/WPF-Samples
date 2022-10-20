using Helix.SharpDX.WPF.NavigationDemo.ViewModels;
using HelixToolkit.SharpDX.Core;
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
        
        var effectsManager = (DataContext as Plot3DViewModel)?.EffectsManager;
        if (effectsManager != null)
        {
            Disposer.RemoveAndDispose(ref effectsManager);
        }

        //Disposer.RemoveAndDispose(ref effectsManager);
        //view3D.Items.Clear();
        //view3D.DataContext = null;
        //view3D.EffectsManager = null;
        //view3D.DataContext = null;
        //view3D.Dispose();
        //view3D.Detach();
        //view3D = null;
    }

    ~Plot3DPage()
    {
        System.Diagnostics.Trace.WriteLine("==== [Plot3DPage] Finalizer ====");
    }
}
