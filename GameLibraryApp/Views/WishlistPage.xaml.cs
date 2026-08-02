using GameLibraryApp.Services;

namespace GameLibraryApp.Views;

public partial class WishlistPage : ContentPage
{
    public WishlistPage()
    {
        InitializeComponent();

        LoadWishlist();
    }

    private void LoadWishlist()
    {
        WishlistCollectionView.ItemsSource = WishlistService.GetWishlist();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadWishlist();
    }
}