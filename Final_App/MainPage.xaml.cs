namespace Final_App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void customize_Clicked(object sender, EventArgs e)
        {
            var page = new CustomizationPage();
            Navigation.PushAsync(page);
        }

        private void play_Clicked(object sender, EventArgs e)
        {
            var page = new HomePage();
            Navigation.PushAsync(page);
        }

        private void settings_Clicked(object sender, EventArgs e)
        {
            var page = new Settings();
            Navigation.PushAsync(page);
        }
    }
}