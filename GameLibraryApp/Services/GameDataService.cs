using System.Collections.Generic;
using GameLibraryApp.Models;

namespace GameLibraryApp.Services;

public class GameDataService
{
    public List<GameItem> GetGames()
    {
        return new List<GameItem>
        {
            new GameItem
            {
                Id = 1,
                Title = "Sky Legends",
                Genre = "Adventure",
                Platform = "PC",
                ReleaseYear = 2022,
                Rating = 4.5,
                Description = "Explore floating islands and uncover ancient secrets.",
                ImageName = "sky_legends.png",
                IsInWishlist = false
            },

            new GameItem
            {
                Id = 2,
                Title = "Speed Rush X",
                Genre = "Racing",
                Platform = "PlayStation",
                ReleaseYear = 2021,
                Rating = 4.2,
                Description = "High-speed racing with realistic physics and tracks.",
                ImageName = "speed_rush.png",
                IsInWishlist = true
            },

            new GameItem
            {
                Id = 3,
                Title = "BattleZone Elite",
                Genre = "Action",
                Platform = "Xbox",
                ReleaseYear = 2023,
                Rating = 4.7,
                Description = "Fast-paced combat in futuristic arenas.",
                ImageName = "battlezone.png",
                IsInWishlist = false
            },

            new GameItem
            {
                Id = 4,
                Title = "Mind Bender",
                Genre = "Puzzle",
                Platform = "Mobile",
                ReleaseYear = 2020,
                Rating = 4.0,
                Description = "Solve challenging puzzles to unlock new levels.",
                ImageName = "mind_bender.png",
                IsInWishlist = true
            },

            new GameItem
            {
                Id = 5,
                Title = "Ultimate Soccer Pro",
                Genre = "Sports",
                Platform = "PC",
                ReleaseYear = 2022,
                Rating = 3.9,
                Description = "Compete in leagues and become a soccer legend.",
                ImageName = "soccer_pro.png",
                IsInWishlist = false
            },

            new GameItem
            {
                Id = 6,
                Title = "Empire Builder",
                Genre = "Strategy",
                Platform = "PC",
                ReleaseYear = 2019,
                Rating = 4.3,
                Description = "Build and manage your empire through the ages.",
                ImageName = "empire_builder.png",
                IsInWishlist = true
            },

            new GameItem
            {
                Id = 7,
                Title = "City Life Simulator",
                Genre = "Simulation",
                Platform = "PC",
                ReleaseYear = 2021,
                Rating = 4.1,
                Description = "Create and manage your own virtual city.",
                ImageName = "city_life.png",
                IsInWishlist = false
            },

            new GameItem
            {
                Id = 8,
                Title = "Dragon Quest Realms",
                Genre = "Adventure",
                Platform = "Switch",
                ReleaseYear = 2023,
                Rating = 4.8,
                Description = "Embark on a magical journey through fantasy lands.",
                ImageName = "dragon_realms.png",
                IsInWishlist = true
            }
        };
    }
}