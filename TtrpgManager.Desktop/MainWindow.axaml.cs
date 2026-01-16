using Avalonia.Controls;
using TtrpgManager.Desktop.ViewModels;

namespace TtrpgManager.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OnLoadClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is CampaignsViewModel vm)
        {
            await vm.LoadAsync();
        }
    }
}