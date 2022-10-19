using System;

using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.SharpDX.WPF.NavigationDemo.ViewModels;

public partial class AboutViewModel : ObservableObject
{
    
    public AboutViewModel()
    {
        System.Diagnostics.Trace.WriteLine("==== [AboutViewModel] Constructor ====");

        _message = "Demonstration how to use Helix Toolkit SharpDX component in the WPF application with the navigation.";
    }

    ~AboutViewModel()
    {
        System.Diagnostics.Trace.WriteLine("==== [AboutViewModel] Finalizer ====");
    }

    #region Properties

    [ObservableProperty]
    private string _message;

    #endregion
}
