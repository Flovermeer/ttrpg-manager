using System;
using System.Net.Http;
using CommunityToolkit.Mvvm.ComponentModel;
using TtrpgManager.Desktop.Api;

namespace TtrpgManager.Desktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase currentViewModel;

    private readonly ITtrpgApiClient api;

    public MainViewModel()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5214")
        };

        api = new TtrpgApiClient(httpClient);

        CurrentViewModel = new HomeViewModel(this, api);
    }

    public void NavigateToCampaign(string campaignName)
    {
        CurrentViewModel = new CampaignViewModel(this, campaignName);
    }

    public void NavigateHome()
    {
        CurrentViewModel = new HomeViewModel(this, api);
    }
}
