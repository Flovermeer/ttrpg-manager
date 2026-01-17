namespace TtrpgManager.Desktop.ViewModels;

public sealed class CampaignViewModel : ViewModelBase
{
    private readonly MainViewModel shell;

    public string CampaignName { get; }

    public CampaignViewModel(MainViewModel shell, string campaignName)
    {
        this.shell = shell;
        CampaignName = campaignName;
    }

    public void BackToHome()
    {
        shell.NavigateHome();
    }
}
