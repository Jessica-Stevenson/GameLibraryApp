using GameLibraryApp.Models;
using System.Collections.ObjectModel;

namespace GameLibraryApp.Services;

public static class WishlistService
{
    private static ObservableCollection<GameItem> _wishlist = new();

    public static ObservableCollection<GameItem> GetWishlist()
    {
        return _wishlist;
    }

    public static void AddToWishlist(GameItem game)
    {
        if (!_wishlist.Contains(game))
        {
            game.IsInWishlist = true;
            _wishlist.Add(game);
        }
    }

    public static void RemoveFromWishlist(GameItem game)
    {
        if (_wishlist.Contains(game))
        {
            game.IsInWishlist = false;
            _wishlist.Remove(game);
        }
    }
}