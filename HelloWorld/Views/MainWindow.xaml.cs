using Wpf.Ui.Controls;

namespace HelloWorld;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : UiWindow
{
    public MainWindow()
    {
        InitializeComponent();

        Wpf.Ui.Appearance.Accent.ApplySystemAccent();
    }
}
