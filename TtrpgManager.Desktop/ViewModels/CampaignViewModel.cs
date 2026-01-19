using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TtrpgManager.Desktop.ViewModels;

public partial class CampaignViewModel : ViewModelBase
{
    [ObservableProperty]
    private string campaignTitle = "Campagne";

    [ObservableProperty]
    private string campaignSubtitle = "Système • Dernière modif • etc.";

    [ObservableProperty]
    private string currentSection = "Adventures";

    public string SectionTitle => CurrentSection;
    public string SectionHint => CurrentSection switch
    {
        "Adventures" => "Chapitres, scènes, chronologie…",
        "NPCs" => "PNJ, factions, relations…",
        "Places" => "Lieux, régions, cartes…",
        "Players" => "PJ, fiches, notes…",
        _ => "—"
    };

    partial void OnCurrentSectionChanged(string value)
    {
        OnPropertyChanged(nameof(SectionTitle));
        OnPropertyChanged(nameof(SectionHint));
    }

    [RelayCommand]
    private void Navigate(string section)
    {
        CurrentSection = section;
    }

    [RelayCommand]
    private void GoHome()
    {
        // TODO: naviguer vers HomeView
    }

    [RelayCommand]
    private void Export()
    {
        // TODO: export PDF/JSON etc.
    }
}
