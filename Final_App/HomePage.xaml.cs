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
}