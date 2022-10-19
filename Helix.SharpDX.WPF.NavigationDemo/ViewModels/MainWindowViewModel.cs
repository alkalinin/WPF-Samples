using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using Helix.SharpDX.WPF.NavigationDemo.Services;

namespace Helix.SharpDX.WPF.NavigationDemo.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private NavigationService _navigationService;

    public MainWindowViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    private void OnNavigatePage(Type pageType)
    {
        _navigationService.Navigate(pageType);
    }
}
