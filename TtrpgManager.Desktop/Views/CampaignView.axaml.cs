using Avalonia.Controls;
using TtrpgManager.Desktop.ViewModels;

namespace TtrpgManager.Desktop.Views;

public partial class CampaignView : UserControl
{
    public CampaignView()
    {
        InitializeComponent();
        DataContext = new CampaignViewModel();
    }
}
