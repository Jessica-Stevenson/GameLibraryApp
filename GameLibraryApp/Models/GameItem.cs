using SQLite;
using System.ComponentModel.DataAnnotations;

namespace GameLibraryApp.Models;

public class GameItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [SQLite.MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [SQLite.MaxLength(50)]
    public string Genre { get; set; } = string.Empty;

    [SQLite.MaxLength(50)]
    public string Platform { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public double Rating { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImageName { get; set; } = string.Empty;

    public bool IsInWishlist { get; set; }
}