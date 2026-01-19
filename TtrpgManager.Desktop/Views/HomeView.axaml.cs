using Avalonia;
using Avalonia.Controls;
using TtrpgManager.Desktop.ViewModels;

namespace TtrpgManager.Desktop.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    // Cette méthode est appelée quand la vue est attachée à l’arbre visuel
    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        // On récupère le ViewModel déjà fourni par DI
        if (DataContext is HomeViewModel vm)
        {
            // On déclenche explicitement le chargement des campagnes
            vm.LoadCommand.Execute(null);
        }
    }
}
