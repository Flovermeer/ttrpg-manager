using Microsoft.Extensions.DependencyInjection;
using System;

namespace TtrpgManager.Desktop.ViewModels;

public class NavigationService : INavigationService
{
    private readonly MainViewModel main;
    private readonly IServiceProvider services;

    public NavigationService(MainViewModel main, IServiceProvider services)
    {
        this.main = main;
        this.services = services;
    }

    public void GoHome()
    {
        main.CurrentViewModel = services.GetRequiredService<HomeViewModel>();
    }

    public void OpenCampaign()
    {
        main.CurrentViewModel = services.GetRequiredService<CampaignViewModel>();
    }
}
