using GameLibraryApp.Models;

namespace GameLibraryApp.Views;

[QueryProperty(nameof(Game), "Game")]
public partial class GameDetailsPage : ContentPage
{
    private GameItem _game;

    public GameItem Game
    {
        get => _game;
        set
        {
            _game = value;
            BindingContext = _game;
        }
    }

    public GameDetailsPage()
    {
        InitializeComponent();
    }
}