using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TtrpgManager.Desktop.Api;

namespace TtrpgManager.Desktop.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    private readonly ITtrpgApiClient Api;
    //private readonly INavigationService NavigationService;
    public ObservableCollection<RecentCampaignItemVm> RecentCampaigns { get; } = new();
    
    // = ref(true) Vue.js
    [ObservableProperty]
    private bool isLoading = false;

    public HomeViewModel(ITtrpgApiClient api)
    {
       this.Api = api;
      // this.NavigationService = navigationService;
    }

    [RelayCommand]
    private async Task LoadAsync()
    {
        try
        {
            IsLoading = true;
            RecentCampaigns.Clear();
            var campaigns = await Api.GetCampaignsAsync();

            foreach (var campaign in campaigns)
            {
                RecentCampaigns.Add(new RecentCampaignItemVm(
                    campaign.Name,
                    campaign.Description));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsLoading = false;
        }

    }

    [RelayCommand]
    private void CreateCampaign()
    {
        // TODO: naviguer vers CampaignView (mode création)
    }

    [RelayCommand]
    private void OpenCampaign()
    {
        // TODO: ouvrir un fichier / picker / ou choisir une récente
    }

    [RelayCommand]
    private void OpenSettings()
    {
        // TODO: settings view
    }
}

public partial class RecentCampaignItemVm : ObservableObject
{
    public string Name { get; }
    public string? Description { get; }


    public RecentCampaignItemVm(string name, string? description = null)
    {
        Name = name;
        Description = description;
    }
}
