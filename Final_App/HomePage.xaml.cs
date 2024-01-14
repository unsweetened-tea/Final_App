using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;

namespace Final_App;

public class WeaponsArgs : EventArgs
{
    public int coins;
    public ObservableCollection<Weapon> weaponsUsed;
    public ObservableCollection<Weapon> weapons;
}

public class SkinsArgs : EventArgs
{
    public int coins;
    public Skin skinUsed;
    public ObservableCollection<Skin> skins;
}

public partial class HomePage : ContentPage
{
    Label selected;
    int coins;
    ObservableCollection<Weapon> weaponsUsed;
    ObservableCollection<Weapon> weapons;
    ObservableCollection<Skin> skins;
    Skin curSkin;

    public HomePage()
    {
        InitializeComponent();
        selected = fam;
        fam.TextColor = Colors.LightBlue;
        coins = 10000;
        coinLabel.Text = "Coins: " + coins.ToString();
        skins = new ObservableCollection<Skin>()
        {
            new Skin()
            {
                Name = "Boy",
                ImageURL = "boy.png",
                Cost = 0,
                Bought = true,
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

        weapons = new ObservableCollection<Weapon>()
        {
            new Weapon()
            {
                Name = "AR-15",
                ImageURL = "weapon1.png",
                Cost = 200,
                Damage = 10,
                Difficulty = 1,
            },
            new Weapon()
            {
                Name = "Deagle",
                ImageURL = "weapon2.png",
                Difficulty = 0,
                Damage = 5,
                Cost = 100,
            },
            new Weapon()
            {
                Name = "Glock",
                ImageURL = "weapon3.png",
                Difficulty = 0,
                Damage = 2,
                Cost = 50,
            },
            new Weapon()
            {
                Name = "AK-47",
                ImageURL = "weapon4.png",
                Difficulty = 1,
                Damage = 15,
                Cost = 350
            },
            new Weapon()
            {
                Name = "Squirt",
                ImageURL = "weapon5.png",
                Damage = 1,
                Cost = 10
            },
            new Weapon()
            {
                Name = "Uzi",
                ImageURL = "weapon6.png",
                Damage = 8,
                Difficulty = 0,
                Cost = 100
            }
        };
    }

    private void start_Clicked(object sender, EventArgs e)
    {
        var page = new Play();
        Navigation.PushAsync(page);
    }

    private void practice_Clicked(object sender, EventArgs e)
    {
        var page = new PlaceholderPractice("family");
        Navigation.PushAsync(page);
        coinLabel.Text = "Coins: " + coins.ToString();
    }

    void weaponButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var page = new WeaponsMenu(coins, weapons);
        page.NavigateAway += onWeaponNavigatAway;
        Navigation.PushAsync(page);
        coinLabel.Text = "Coins: " + coins.ToString();
    }

    void skinsButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var page = new SkinsMenu(coins, skins);
        page.NavigateAway += onSkinNavigatAway;
        Navigation.PushAsync(page);
    }
    void Level_Clicked(System.Object sender, System.EventArgs e)
    {
        var button = sender as ImageButton;
        if (button == null)
            return;
        var URL = button.Source.ToString().Substring(6);
        if (URL.Equals("family.png"))
        {
            fam.TextColor = Colors.LightBlue;
            selected.TextColor = Colors.Black;
            selected = fam;
        }
        else if (URL.Equals("food.png"))
        {
            fod.TextColor = Colors.LightBlue;
            selected.TextColor = Colors.Black;
            selected = fod;
        }
        else if (URL.Equals("likedislike.png"))
        {
            fav.TextColor = Colors.LightBlue;
            selected.TextColor = Colors.Black;
            selected = fav;
            
        }
        else if (URL.Equals("travel.png"))
        {
            trav.TextColor = Colors.LightBlue;
            selected.TextColor = Colors.Black;
            selected = trav;
        }
        else if (URL.Equals("basics.png"))
        {
            gret.TextColor = Colors.LightBlue;
            selected.TextColor = Colors.Black;
            selected = gret;
        }
    }

    void onWeaponNavigatAway(object sender, WeaponsArgs e)
    {
        coins = e.coins;
        weaponsUsed = e.weaponsUsed;
        weapons = e.weapons;
        coinLabel.Text = "Coins: " + coins.ToString();
    }

    void onSkinNavigatAway(object sender, SkinsArgs e)
    {
        coins = e.coins;
        curSkin = e.skinUsed;
        skins = e.skins;
        coinLabel.Text = "Coins: " + coins.ToString();
    }

}
