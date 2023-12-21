using FinalProject;

namespace Final_App;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void start_Clicked(object sender, EventArgs e)
    {
        var page = new PlaceholderPlay();
        Navigation.PushAsync(page);
    }

    private void practice_Clicked(object sender, EventArgs e)
    {
        var page = new PlaceholderPractice();
        Navigation.PushAsync(page);
    }

    void weaponButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var page = new WeaponsMenu();
        Navigation.PushAsync(page);
    }

    void skinsButton_Clicked(System.Object sender, System.EventArgs e)
    {
        //var page = new SkinsMenu();
        //Navigation.PushAsync(page)
    }
}