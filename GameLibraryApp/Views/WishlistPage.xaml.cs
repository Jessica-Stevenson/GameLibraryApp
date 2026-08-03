using GameLibraryApp.Models;
using GameLibraryApp.Services;

namespace GameLibraryApp.Views;

public partial class WishlistPage : ContentPage
{
    private readonly GameDatabaseService _databaseService;

    public WishlistPage(GameDatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LoadWishlistAsync();
    }


    private async Task LoadWishlistAsync()
    {
        var games = await _databaseService.GetGamesAsync();


        var wishlistGames = games
            .Where(game => game.IsInWishlist)
            .ToList();


        WishlistCollectionView.ItemsSource = wishlistGames;
    }

    private async void OnAddToWishlistClicked(object sender, EventArgs e)
    {
        var game = (GameItem)((Button)sender).BindingContext;

        game.IsInWishlist = true;

        await _databaseService.UpdateGameAsync(game);

        await DisplayAlert(
            "Wishlist",
            $"{game.Title} added to wishlist!",
            "OK");
    }
}