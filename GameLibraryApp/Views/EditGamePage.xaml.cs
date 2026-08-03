using GameLibraryApp.Models;
using GameLibraryApp.Services;

namespace GameLibraryApp.Views;

[QueryProperty(nameof(GameId), "id")]
public partial class EditGamePage : ContentPage
{
    private readonly GameDatabaseService _databaseService;

    private GameItem _game;

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

    public EditGamePage(GameDatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
    }

    private async void LoadGame()
    {
        _game = await _databaseService.GetGameAsync(_gameId);

        if (_game == null)
        {
            await DisplayAlert(
                "Game Not Found",
                "The selected game could not be found.",
                "OK"
            );

            await Shell.Current.GoToAsync("..");

            return;
        }


        TitleEntry.Text = _game.Title;
        GenreEntry.Text = _game.Genre;
        PlatformEntry.Text = _game.Platform;
        ReleaseYearEntry.Text = _game.ReleaseYear.ToString();
        RatingEntry.Text = _game.Rating.ToString();
        DescriptionEditor.Text = _game.Description;
        WishlistSwitch.IsToggled = _game.IsInWishlist;
    }

    private async void OnUpdateGameClicked(object sender, EventArgs e)
    {
        //Basic validation
        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlert("Error", "Title is required", "OK");
            return;
        }

        if (!int.TryParse(ReleaseYearEntry.Text, out int year))
        {
            await DisplayAlert("Error", "Invalid release year", "OK");
            return;
        }

        if (!double.TryParse(RatingEntry.Text, out double rating))
        {
            await DisplayAlert("Error", "Invalid rating", "OK");
            return;
        }

        //Update object with new values
        _game.Title = TitleEntry.Text;
        _game.Genre = GenreEntry.Text;
        _game.Platform = PlatformEntry.Text;
        _game.ReleaseYear = year;
        _game.Rating = rating;
        _game.Description = DescriptionEditor.Text;
        _game.IsInWishlist = WishlistSwitch.IsToggled;

        //Save changes to database
        await _databaseService.UpdateGameAsync(_game);

        int result = await _databaseService.UpdateGameAsync(_game);

        if (result == 0)
        {
            await DisplayAlert(
                "Update Failed",
                "The game could not be updated because it no longer exists.",
                "OK"
            );

            return;
        }

        await DisplayAlert("Success", "Game updated successfully.", "OK");

        //Navigate back to previous page
        await Shell.Current.GoToAsync("..");
    }

    private async void OnDeleteGameClicked(object sender, EventArgs e)
    {
        bool confirmDelete = await DisplayAlert(
            "Delete Game",
            "Are you sure you want to delete this game?",
            "Yes",
            "No"
        );


        if (!confirmDelete)
        {
            return;
        }


        int result = await _databaseService.DeleteGameAsync(_game);


        if (result == 0)
        {
            await DisplayAlert(
                "Delete Failed",
                "The game could not be deleted because it no longer exists.",
                "OK"
            );

            return;
        }


        await DisplayAlert(
            "Deleted",
            "Game deleted successfully.",
            "OK"
        );


        await Shell.Current.GoToAsync("..");
    }
}