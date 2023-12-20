using System;
using System.Windows;
using System.Windows.Controls;


namespace FinalProject;

public partial class WeaponSelection : ContentPage
{
	public WeaponSelection()
	{
		InitializeComponent();
	}

    private void WeaponButton_Click(object sender, RoutedEventArgs e)
    {
        // Add logic for handling weapon button clicks here
        // For example:
        Button clickedButton = (Button)sender;
        MessageBox.Show($"You clicked on {clickedButton.Name}!");
    }

    // Event handler for Buy button click
    private void BuyButton_Click(object sender, RoutedEventArgs e)
    {
        // Add logic for handling Buy button click here
        MessageBox.Show("Buy button clicked!");
    }
}
