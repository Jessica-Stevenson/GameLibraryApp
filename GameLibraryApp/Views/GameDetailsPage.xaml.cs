using GameLibraryApp.Models;
using GameLibraryApp.Services;

namespace GameLibraryApp.Views;

[QueryProperty(nameof(GameId), "id")]
public partial class GameDetailsPage : ContentPage
{
    private readonly GameDatabaseService _databaseService;

    private int _gameId;

    public int GameId
    {
        get => _gameId;
        set
        {
            _gameId = value;
            LoadGame();
        }
    }

    public GameDetailsPage(GameDatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
    }

    private async void LoadGame()
    {
        var game = await _databaseService.GetGameAsync(_gameId);

        if (game == null)
        {
            await DisplayAlert(
                "Game Not Found",
                "The selected game could not be found.",
                "OK"
            );

            await Shell.Current.GoToAsync("..");

            return;
        }

        BindingContext = game;
    }
}