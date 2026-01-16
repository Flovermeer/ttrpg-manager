using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.Net.Http;
using TtrpgManager.Desktop.Api;
using TtrpgManager.Desktop.ViewModels;

namespace TtrpgManager.Desktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // 1) HTTP client (réutilisé dans toute l'app)
            var httpClient = CreateHttpClient();

            // 2) Client API (wrapper autour de HttpClient)
            var apiClient = new TtrpgApiClient(httpClient);

            // 3) ViewModel racine (pour la MainWindow)
            var campaignsViewModel = new CampaignsViewModel(apiClient);

            // 4) Fenêtre principale + DataContext
            desktop.MainWindow = new MainWindow
            {
                DataContext = campaignsViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static HttpClient CreateHttpClient()
    {
        // TODO: plus tard -> mettre ça dans une config (appsettings, env var, etc.)
        return new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5214")
        };
    }
}