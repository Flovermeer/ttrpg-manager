using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TtrpgManager.Desktop.Api;

namespace TtrpgManager.Desktop.ViewModels;

public sealed class CampaignsViewModel
{
    private readonly TtrpgApiClient _api;

    // Liste observable = équivalent du state réactif en Vue
    public ObservableCollection<CampaignDto> Campaigns { get; } = new();

    public CampaignsViewModel(TtrpgApiClient api)
    {
        _api = api;
    }

    // Méthode appelée par la View (bouton, chargement, etc.)
    public async Task LoadAsync()
    {
        Campaigns.Clear();

        var items = await _api.ListCampaignsAsync();

        foreach (var campaign in items)
        {
            Campaigns.Add(campaign);
        }
    }
}

