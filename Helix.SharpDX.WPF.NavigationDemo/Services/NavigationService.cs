using System;
using System.Windows.Controls;

namespace Helix.SharpDX.WPF.NavigationDemo.Services;

public class NavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private Frame _navigationControl;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Frame NavigationControl
    {
        get => _navigationControl;
        set => _navigationControl = value;
    }

    public bool Navigate(Type pageType)
    {
        if (NavigationControl == null)
            return false;

        if (NavigationControl.CanGoBack)
        {
            NavigationControl.RemoveBackEntry();
        }

        return NavigationControl.Navigate(_serviceProvider.GetService(pageType));
    }
}
