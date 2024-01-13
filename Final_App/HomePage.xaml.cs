using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;

namespace Final_App;
public partial class HomePage : ContentPage
{
    Label selected;
    public HomePage()
    {
        InitializeComponent();
        selected = fam;
        fam.TextColor = Colors.LightBlue;
        Preferences.Default.Set("skinsUsed", new ObservableCollection<Skin>());
        Preferences.Default.Set("weaponsUsed", new ObservableCollection<Weapon>());

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
    }

    void weaponButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var page = new WeaponsMenu();
        Navigation.PushAsync(page);
    }

    void skinsButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var page = new SkinsMenu();
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

}
