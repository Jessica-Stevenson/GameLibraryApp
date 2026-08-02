using GameLibraryApp.Models;
using GameLibraryApp.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace GameLibraryApp.Views;

public partial class GamesPage : ContentPage
{
    private readonly GameDatabaseService _databaseService;

    private List<GameItem> _allGames = new();

    private ObservableCollection<GameItem> _filteredGames = new();
    private async void OnAddGameClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddGamePage));
    }

    public GamesPage(GameDatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;

        GamesCollectionView.ItemsSource = _filteredGames;

        GenrePicker.SelectedIndex = 0;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LoadGamesAsync();
    }


    private async Task LoadGamesAsync()
    {
        // Get games from SQLite
        _allGames = await _databaseService.GetGamesAsync();


        // Refresh displayed list
        _filteredGames.Clear();

        foreach (var game in _allGames)
        {
            _filteredGames.Add(game);
        }


        UpdateResultCount();
    }


    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        ApplyFilters();
    }


    private void OnGenreChanged(object sender, EventArgs e)
    {
        ApplyFilters();
    }


    private void ApplyFilters()
    {
        string searchText = GameSearchBar.Text?.ToLower() ?? "";

        string selectedGenre = GenrePicker.SelectedItem?.ToString();


        var results = _allGames.Where(game =>
            game.Title.ToLower().Contains(searchText)
            &&
            (
                selectedGenre == "All Genres"
                ||
                string.IsNullOrEmpty(selectedGenre)
                ||
                game.Genre == selectedGenre
            )
        ).ToList();


        _filteredGames.Clear();


        foreach (var game in results)
        {
            _filteredGames.Add(game);
        }


        UpdateResultCount();
    }


    private void UpdateResultCount()
    {
        int count = _filteredGames.Count;


        ResultCountLabel.Text =
            $"Showing {count} game{(count == 1 ? "" : "s")}";


        NoResultsLabel.IsVisible = count == 0;
    }


    private async void OnViewDetailsClicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        var game = button?.BindingContext as GameItem;


        if (game != null)
        {
            await Shell.Current.GoToAsync(
                nameof(GameDetailsPage),
                true,
                new Dictionary<string, object>
                {
                    { "Game", game }
                });
        }
    }


    private async void OnAddToWishlistClicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        var game = button?.BindingContext as GameItem;


        if (game != null)
        {
            await _databaseService.SaveGameAsync(game);


            await DisplayAlert(
                "Wishlist",
                $"{game.Title} added to wishlist!",
                "OK");
        }
    }
}