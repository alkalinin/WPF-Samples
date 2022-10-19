using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

using Helix.SharpDX.WPF.NavigationDemo.Views;

namespace Helix.SharpDX.WPF.NavigationDemo.Services;


/// <summary>
/// Application host service, it is responsible for the application startup and shutdown.
/// </summary>
public class ApplicationHostService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationHostService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var mainWindow = _serviceProvider.GetService(typeof(MainWindow)) as MainWindow;
        mainWindow!.Show();

        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}
