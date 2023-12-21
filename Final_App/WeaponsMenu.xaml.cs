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
        Button clickedButton = (Button)sender;
        GetResponse();
    }

    // Event handler for Buy button click
    private async void BuyButton_Click(object sender, EventArgs e)
    {
        // Add logic for handling Buy button click here
        await DisplayAlert("Weapon bought", "You bought a weapon!", "Ok");
    }
}
