using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TtrpgManager.Desktop.Api;


namespace TtrpgManager.Desktop.ViewModels;

public sealed class HomeViewModel : ViewModelBase
{
    private readonly MainViewModel shell;
    private readonly ITtrpgApiClient api;

    // Liste observable = équivalent du state réactif en Vue
    public ObservableCollection<CampaignDto> Campaigns { get; } = new();

    public HomeViewModel(MainViewModel shell, ITtrpgApiClient api)
    {
        this.shell = shell;
        this.api = api;
    }

    // Chargement des campagnes (appelé par la View)
    public async Task LoadAsync()
    {
        Campaigns.Clear();

        var items = await api.ListCampaignsAsync();
        foreach (var campaign in items)
        {
            Campaigns.Add(campaign);
        }
    }

    // Ouverture d’une campagne depuis la liste
    public void OpenCampaign(CampaignDto campaign)
    {
        if (campaign == null)
        {
            return;
        }

        shell.NavigateToCampaign(campaign.Name);
    }
}
