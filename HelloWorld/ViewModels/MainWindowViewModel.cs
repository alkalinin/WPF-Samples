using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HelloWorld.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private int _clicksCount = 0;

    [RelayCommand]
    private void OnClick() => ClicksCount++;
}
