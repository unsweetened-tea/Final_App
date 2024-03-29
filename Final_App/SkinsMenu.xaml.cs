using System.Collections.ObjectModel;

namespace Final_App;

public partial class SkinsMenu : ContentPage
{
    ObservableCollection<Skin> skins;
    Skin skin;
    int coinsLeft;
    public event EventHandler<SkinsArgs> NavigateAway;

    public SkinsMenu(int coins)
    {
        coinsLeft = coins;
        
        skins = new ObservableCollection<Skin>()
        {
            new Skin()
            {
                Name = "Boy",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\boy.png",
                Cost = 0,
                Bought = true,
            },
            new Skin()
            {
                Name = "Dino",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\dino.png",
                Cost = 100,
            },
            new Skin()
            {
                Name = "Knight",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\knight.png",
                Cost = 50,
            },
            new Skin()
            {
                Name = "Red Hat",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\redhat.png",
                Cost = 350
            },
            new Skin()
            {
                Name = "Zombie",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\zombie.png",
                Cost = 10
            },
            new Skin()
            {
                Name = "Pumpkin",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\pumpkin.png",
                Cost = 100
            }
        };
        skinsCollection.ItemsSource = skins;
        skinsCollection.SelectedItem = skins[0];
        skin = skins[0];
        buyButton.IsEnabled = false;
        useButton.IsEnabled = false;
        coinLabel.Text = "Coins: " + coinsLeft.ToString();
        InitializeComponent();
    }

    public SkinsMenu(int coins, ObservableCollection<Skin> skins)
    {
        coinsLeft = coins;
        InitializeComponent();
        this.skins = skins;
        skinsCollection.ItemsSource = skins;
        skin = skins[0];
        skinsCollection.SelectedItem = skins[0];
        buyButton.IsEnabled = false;
        useButton.IsEnabled = false;
        coinLabel.Text = "Coins: " + coinsLeft.ToString();
    }

    public SkinsMenu(int coins, ObservableCollection<Skin> skins, Skin skinUsed)
    {
        coinsLeft = coins;
        InitializeComponent();
        //this.skins = skins;
        skinsCollection.ItemsSource = skins;
        skinsCollection.SelectedItem = skinUsed;
        skin = skinUsed;
        buyButton.IsEnabled = false;
        useButton.IsEnabled = false;
        coinLabel.Text = "Coins: " + coinsLeft.ToString();
    }

    private async void GetResponse()
    {
        await DisplayAlert("Button clicked", "You clicked on a skin!", "Ok");
    }

    private async void SkinButton_Click(object sender, EventArgs e)
    {
        // Add logic for handling skin button clicks here
        // For example:
        var clickedButton = sender as ImageButton;
        GetResponse();
        var image = new Image()
        {
            Source = clickedButton.Source,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.Blue,
        };

    }

    // Event handler for Buy button click
    private async void BuyButton_Click(object sender, EventArgs e)
    {
        // Add logic for handling Buy button click here
        await DisplayAlert("Skin bought", "You bought a skin!", "Ok");
        var skin = skinsCollection.SelectedItem as Skin;
        skin.Bought = true;
        buyButton.IsEnabled = false;
        useButton.IsEnabled = true;
        coinsLeft -= skin.Cost;
        coinLabel.Text = "Coins: " + coinsLeft.ToString();
    }

    async void useButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (useButton.Text == "Equip")
        {
            useButton.IsEnabled = false;
            skin = skinsCollection.SelectedItem as Skin;
        }
    }

    void CollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var skin = skinsCollection.SelectedItem as Skin;
        if (skin != null) 
        {
            selectedImage.Source = skin.ImageURL;

            skinData.Text = "Name: " + skin.Name + "\nCost: " + skin.Cost;
            if (skin.Bought)
            {
                if (this.skin == skin) useButton.IsEnabled = false;
                else useButton.IsEnabled = true;
                buyButton.IsEnabled = false;
            }
            else
            {
                useButton.Text = "Equip";
                useButton.IsEnabled = false;
                if (skin.Cost > coinsLeft) buyButton.IsEnabled = false;
                else buyButton.IsEnabled = true;
            }
        }
        

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        NavigateAway?.Invoke(this, new SkinsArgs() { coins = this.coinsLeft, skinUsed = skin, skins = this.skins });
    }
}
