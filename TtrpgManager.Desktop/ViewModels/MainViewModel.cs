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

    public MainViewModel(HomeViewModel homeViewModel)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5214")
        };

        api = new TtrpgApiClient(httpClient);

        CurrentViewModel = homeViewModel;
    }

    public void NavigateToCampaign(string campaignName)
    {
        CurrentViewModel = new CampaignViewModel();
    }

    public void NavigateHome()
    {
    //    CurrentViewModel = new HomeViewModel();
    }

    public void NavigateHomePage()
    {
       // var vm = services.GetRequiredService<HomeViewModel>();
      //  CurrentViewModel = vm;
     //   vm.LoadAsyncCommand.Execute(null);
    }
}
