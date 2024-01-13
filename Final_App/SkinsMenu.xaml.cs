using System.Collections.ObjectModel;

namespace Final_App;

public partial class SkinsMenu : ContentPage
{
    ObservableCollection<Skin> skins;
    ObservableCollection<Skin> skinsUsed;
    public SkinsMenu()
    {
        InitializeComponent();
        skins = new ObservableCollection<Skin>()
        {
            new Skin()
            {
                Name = "Boy",
                ImageURL = "boy.png",
                Cost = 200,
            },
            new Skin()
            {
                Name = "Dino",
                ImageURL = "dino.png",
                Cost = 100,
            },
            new Skin()
            {
                Name = "Knight",
                ImageURL = "knight.png",
                Cost = 50,
            },
            new Skin()
            {
                Name = "Red Hat",
                ImageURL = "redhat.png",
                Cost = 350
            },
            new Skin()
            {
                Name = "Zombie",
                ImageURL = "zombie.png",
                Cost = 10
            },
            new Skin()
            {
                Name = "Pumpkin",
                ImageURL = "pumpkin.png",
                Cost = 100
            }
        };
        skinsUsed = new ObservableCollection<Skin>()
        {

        };
        skinsCollection.ItemsSource = skins;
        skinsCollection.SelectedItem = skins[0];
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
    }

    async void useButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (useButton.Text == "Equip")
        {
            useButton.Text = "Unequip";
            skinsUsed.Add(skinsCollection.SelectedItem as Skin);
        }
        else
        {
            skinsUsed.Remove(skinsCollection.SelectedItem as Skin);
            useButton.Text = "Equip";
        }

    }

    void CollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var skin = skinsCollection.SelectedItem as Skin;
        selectedImage.Source = skin.ImageURL;
        if (skin.Bought)
        {
            if (!skinsUsed.Contains(skin)) useButton.Text = "Equip";
            else useButton.Text = "Unequip";
            useButton.IsEnabled = true;

            buyButton.IsEnabled = false;
        }
        else
        {
            useButton.Text = "Equip";
            useButton.IsEnabled = false;
            buyButton.IsEnabled = true;
        }



    }
}
