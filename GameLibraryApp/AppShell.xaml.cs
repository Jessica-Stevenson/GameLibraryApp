using GameLibraryApp.Views;

namespace GameLibraryApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(GameDetailsPage), typeof(GameDetailsPage));

        Routing.RegisterRoute(nameof(AddGamePage), typeof(AddGamePage));

        Routing.RegisterRoute(nameof(EditGamePage), typeof(EditGamePage));
    }
}