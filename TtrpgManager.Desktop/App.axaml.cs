using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using TtrpgManager.Desktop.Api;
using TtrpgManager.Desktop.ViewModels;


namespace TtrpgManager.Desktop;

public partial class App : Application
{
    public IServiceProvider Services { get; private set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        services.AddSingleton(new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5214") // ton API
        });
        services.AddSingleton<ITtrpgApiClient, TtrpgApiClient>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<MainViewModel>();




        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Services = services.BuildServiceProvider();

            desktop.MainWindow = new MainWindow
            {
                DataContext = Services.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
