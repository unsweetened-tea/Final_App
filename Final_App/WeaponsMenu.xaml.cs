using System.Collections.ObjectModel;

namespace Final_App;

public partial class WeaponsMenu : ContentPage
{
    ObservableCollection<Weapon> weapons;
    ObservableCollection<Weapon> weaponsUsed;
    public event EventHandler<WeaponsArgs> NavigateAway;
    int coinsLeft;
    public WeaponsMenu(int coins)
    {
        coinsLeft = coins;
        InitializeComponent();
        weapons = new ObservableCollection<Weapon>()
        {
            new Weapon()
            {
                Name = "Squirt",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\weapon5.png",
                Damage = 1,
                Cost = 10,
                Difficulty = 0
            },
            new Weapon()
            {
                Name = "Glock",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\weapon3.png",
                Difficulty = 0,
                Damage = 2,
                Cost = 50,
            },
            new Weapon()
            {
                Name = "Deagle",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\weapon2.png",
                Difficulty = 0,
                Damage = 5,
                Cost = 100,
            },
            new Weapon()
            {
                Name = "Uzi",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\weapon6.png",
                Damage = 8,
                Difficulty = 0,
                Cost = 100
            },
            new Weapon()
            {
                Name = "AR-15",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\weapon1.png",
                Cost = 200,
                Damage = 10,
                Difficulty = 1,
            },
            new Weapon()
            {
                Name = "AK-47",
                ImageURL = "C:\\Users\\leogo\\source\\repos\\Final_App\\Final_App\\Resources\\Images\\weapon4.png",
                Difficulty = 2,
                Damage = 15,
                Cost = 350
            },
            
        };
        weaponsUsed = new ObservableCollection<Weapon>()
        {

        };
        weaponsCollection.ItemsSource = weapons;
        weaponsCollection.SelectedItem = weapons[0];
        
        buyButton.IsEnabled = false;
        useButton.Text = "Unequip";
        coinLabel.Text = "Coins: " + coins.ToString();
    }

    public WeaponsMenu(int coins, ObservableCollection<Weapon> weapons)
    {
        coinsLeft = coins;
        InitializeComponent();
        this.weapons = weapons;
        if (weaponsUsed == null)
        {
            weaponsUsed = new ObservableCollection<Weapon>()
            {

            };
        }
        
        weaponsUsed.Add(weapons[0]);
        weapons[0].Bought = true;
        weaponsCollection.ItemsSource = weapons;
        weaponsCollection.SelectedItem = weapons[0];

        buyButton.IsEnabled = false;
        useButton.Text = "Unequip";
        coinLabel.Text = "Coins: " + coinsLeft.ToString();

    }

    public WeaponsMenu(int coins, ObservableCollection<Weapon> weapons, ObservableCollection<Weapon> weaponsUsed)
    {
        coinsLeft = coins;
        InitializeComponent();
        this.weapons = weapons;
        this.weaponsUsed = weaponsUsed;
        weaponsCollection.ItemsSource = weapons;
        weaponsCollection.SelectedItem = weapons[0];

        buyButton.IsEnabled = false;
        useButton.Text = "Unequip";
        coinLabel.Text = "Coins: " + coinsLeft.ToString();
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
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.Blue,
        };

    }

    // Event handler for Buy button click
    private async void BuyButton_Click(object sender, EventArgs e)
    {
        // Add logic for handling Buy button click here
        await DisplayAlert("Weapon bought", "You bought a weapon!", "Ok");
        var weapon = weaponsCollection.SelectedItem as Weapon;
        weapon.Bought = true;
        buyButton.IsEnabled = false;
        useButton.IsEnabled = true;
        coinsLeft -= weapon.Cost;
        coinLabel.Text = "Coins: " + coinsLeft.ToString();
    }

    async void useButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (useButton.Text == "Equip")
        {
            useButton.Text = "Unequip";
            weaponsUsed.Add(weaponsCollection.SelectedItem as Weapon);
            if (weaponsUsed.Count >= 4) weaponsUsed.RemoveAt(0);
        }
        else
        {
            weaponsUsed.Remove(weaponsCollection.SelectedItem as Weapon);
            useButton.Text = "Equip";
        }

    }

    void CollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var weapon = weaponsCollection.SelectedItem as Weapon;
        if (weapon != null) 
        {
            selectedImage.Source = weapon.ImageURL;
            string difficulty;
            if (weapon.Difficulty == 0) difficulty = "Easy";
            else if (weapon.Difficulty == 1) difficulty = "Medium";
            else difficulty = "Hard";
            weaponData.Text = "Name: " + weapon.Name + "\nCost: " + weapon.Cost + "\nDamage: " + weapon.Damage + "\nDifficulty: " + difficulty;
            if (weapon.Bought)
            {
                if (!weaponsUsed.Contains(weapon)) useButton.Text = "Equip";
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

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        NavigateAway?.Invoke(this, new WeaponsArgs() { coins = this.coinsLeft, weaponsUsed = this.weaponsUsed, weapons = this.weapons });
    }
}