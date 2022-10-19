using System.Windows;
using System.Windows.Threading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Helix.SharpDX.WPF.NavigationDemo.Services;
using Helix.SharpDX.WPF.NavigationDemo.Views;
using Helix.SharpDX.WPF.NavigationDemo.Views.Pages;
using Helix.SharpDX.WPF.NavigationDemo.ViewModels;

namespace Helix.SharpDX.WPF.NavigationDemo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private static readonly IHost s_host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // Application Host: startup, shutdown
            services.AddHostedService<ApplicationHostService>();

            // Navigation
            services.AddSingleton<NavigationService>();

            // Views and ViewModels

            // Main Window
            services.AddScoped<MainWindow>();
            services.AddScoped<MainWindowViewModel>();

            // Pages
            services.AddTransient<AboutPage>();
            services.AddTransient<AboutViewModel>();

            services.AddTransient<Plot3DPage>();
            services.AddTransient<Plot3DViewModel>();
        }).Build();

    public static T? GetService<T>()
        where T : class
    {
        return s_host.Services.GetService(typeof(T)) as T;
    }

    private async void OnStartup(object sender, StartupEventArgs e)
    {
        await s_host.StartAsync();
    }

    private async void OnExit(object sender, ExitEventArgs e)
    {
        await s_host.StopAsync();

        s_host.Dispose();
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
    }
}
