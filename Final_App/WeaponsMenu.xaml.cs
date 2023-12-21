using System;


namespace FinalProject;

public partial class WeaponsMenu : ContentPage
{
	public WeaponsMenu()
	{
		InitializeComponent();
	}

    private async void GetResponse()
    {
        await DisplayAlert("Button clicked", "You clicked on a weapon!", "Ok");
    }

    private async void WeaponButton_Click(object sender, EventArgs e)
    {
        // Add logic for handling weapon button clicks here
        // For example:
        var clickedButton = sender as ImageButton;
        GetResponse();
        var image = new Image()
        {
            Source = clickedButton.Source,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.Blue,
        };
        WeaponsGrid.Add(image, 0, 0);
        WeaponsGrid.SetColumnSpan(image, 2);
        WeaponsGrid.SetRowSpan(image, 2);
        WeaponsGrid.BackgroundColor = Colors.Teal;
        
        
    }

    // Event handler for Buy button click
    private async void BuyButton_Click(object sender, EventArgs e)
    {
        // Add logic for handling Buy button click here
        await DisplayAlert("Weapon bought", "You bought a weapon!", "Ok");
    }
}
