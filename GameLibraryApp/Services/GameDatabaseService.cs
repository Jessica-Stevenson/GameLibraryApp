using SQLite;
using GameLibraryApp.Models;

namespace GameLibraryApp.Services;

public class GameDatabaseService
{
    private SQLiteAsyncConnection? _database;

    private const string DatabaseFilename = "gamelibrary.db3";


    public async Task InitialiseAsync()
    {
        if (_database != null)
        {
            return;
        }


        string databasePath = Path.Combine(
            FileSystem.AppDataDirectory,
            DatabaseFilename
        );


        _database = new SQLiteAsyncConnection(databasePath);


        await _database.CreateTableAsync<GameItem>();


        await SeedDatabaseAsync();
    }

    private async Task SeedDatabaseAsync()
    {
        if (_database == null)
        {
            return;
        }

        var count = await _database
            .Table<GameItem>()
            .CountAsync();


        if (count > 0)
        {
            return;
        }


        List<GameItem> sampleGames = new()
    {
        new GameItem
        {
            Title = "Minecraft",
            Genre = "Adventure",
            Platform = "PC",
            ReleaseYear = 2011,
            Rating = 9.5,
            Description = "A sandbox game where players explore, build, and survive.",
            ImageName = "minecraft.png",
            IsInWishlist = false
        },

        new GameItem
        {
            Title = "Mario Kart 8 Deluxe",
            Genre = "Racing",
            Platform = "Nintendo Switch",
            ReleaseYear = 2017,
            Rating = 9.0,
            Description = "A racing game featuring characters from the Mario universe.",
            ImageName = "mariokart.png",
            IsInWishlist = true
        },

        new GameItem
        {
            Title = "Elden Ring",
            Genre = "RPG",
            Platform = "PlayStation",
            ReleaseYear = 2022,
            Rating = 9.7,
            Description = "An action RPG set in a large fantasy open world.",
            ImageName = "eldenring.png",
            IsInWishlist = false
        }
    };


        await _database.InsertAllAsync(sampleGames);
    }


    //Read
    public async Task<List<GameItem>> GetGamesAsync()
    {
        await InitialiseAsync();

        return await _database!
            .Table<GameItem>()
            .ToListAsync();
    }


    //Read
    public async Task<GameItem?> GetGameAsync(int id)
    {
        await InitialiseAsync();

        return await _database!
            .Table<GameItem>()
            .Where(game => game.Id == id)
            .FirstOrDefaultAsync();
    }


    //Create, Update
    public async Task<int> SaveGameAsync(GameItem game)
    {
        await InitialiseAsync();

        if (game.Id != 0)
        {
            return await _database!
                .UpdateAsync(game);
        }
        else
        {
            return await _database!
                .InsertAsync(game);
        }
    }
    // Update
    public async Task<int> UpdateGameAsync(GameItem game)
    {
        await InitialiseAsync();

        return await _database!
            .UpdateAsync(game);
    }


    //Delete
    public async Task<int> DeleteGameAsync(GameItem game)
    {
        await InitialiseAsync();

        if (game == null)
        {
            return 0;
        }

        return await _database!
            .DeleteAsync(game);
    }
}