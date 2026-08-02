using GameLibraryApp.Models;
using GameLibraryApp.Services;

namespace GameLibraryApp.Views;

public partial class AddGamePage : ContentPage
{
    private readonly GameDatabaseService _databaseService;

    public AddGamePage(GameDatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;
    }

    private async void OnSaveGameClicked(object sender, EventArgs e)
    {
        ResultLabel.TextColor = Colors.Red;

        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            ResultLabel.Text = "Please enter a game title.";
            return;
        }

        if (GenrePicker.SelectedItem == null)
        {
            ResultLabel.Text = "Please select a genre.";
            return;
        }

        if (PlatformPicker.SelectedItem == null)
        {
            ResultLabel.Text = "Please select a platform.";
            return;
        }

        if (!int.TryParse(ReleaseYearEntry.Text, out int releaseYear))
        {
            ResultLabel.Text = "Please enter a valid release year.";
            return;
        }

        if (!double.TryParse(RatingEntry.Text, out double rating))
        {
            ResultLabel.Text = "Please enter a valid rating.";
            return;
        }

        if (rating < 0 || rating > 10)
        {
            ResultLabel.Text = "Rating must be between 0 and 10.";
            return;
        }

        if (string.IsNullOrWhiteSpace(DescriptionEditor.Text))
        {
            ResultLabel.Text = "Please enter a description.";
            return;
        }

        GameItem game = new()
        {
            Title = TitleEntry.Text,
            Genre = GenrePicker.SelectedItem.ToString(),
            Platform = PlatformPicker.SelectedItem.ToString(),
            ReleaseYear = releaseYear,
            Rating = rating,
            Description = DescriptionEditor.Text,
            ImageName = ImageNameEntry.Text,
            IsInWishlist = WishlistSwitch.IsToggled
        };

        await _databaseService.SaveGameAsync(game);

        ResultLabel.TextColor = Colors.Green;
        ResultLabel.Text = "Game saved successfully.";


        TitleEntry.Text = string.Empty;
        GenrePicker.SelectedItem = null;
        PlatformPicker.SelectedItem = null;
        ReleaseYearEntry.Text = string.Empty;
        RatingEntry.Text = string.Empty;
        DescriptionEditor.Text = string.Empty;
        ImageNameEntry.Text = string.Empty;
        WishlistSwitch.IsToggled = false;

        await Shell.Current.GoToAsync("..");

    }
}