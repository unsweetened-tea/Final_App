namespace Final_App;

public partial class CustomizationPage : ContentPage
{
	public CustomizationPage()
	{
		InitializeComponent();
	}

    private void weapons_Clicked(object sender, EventArgs e)
    {
        var page = new WeaponsMenu();
        Navigation.PushAsync(page);
    }

    private void skins_Clicked(object sender, EventArgs e)
    {
        var page = new SkinsMenu();
        Navigation.PushAsync(page);
    }
}