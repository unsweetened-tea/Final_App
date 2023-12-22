using System.Net.Sockets;

namespace Final_App;
public partial class HomePage : ContentPage
{
    public int selected = 0;
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
    void Level_Clicked(System.Object sender, System.EventArgs e)
    {
        var button = sender as ImageButton;
        if (button == null)
            return;
        else if(selected == 1)
        {
            fam.TextColor = Colors.White;
        }
        else if (selected == 2)
        {
            fod.TextColor = Colors.White;
        }
        else if (selected == 3)
        {
            fav.TextColor = Colors.White;
        }
        else if (selected == 4)
        {
            trav.TextColor = Colors.White;
        }
        else if (selected == 5)
        {
            gret.TextColor = Colors.White;
        }

        else if (button.Source.Equals("Family.png"))
        {
            fam.TextColor = Colors.Yellow;
            selected = 1;
        }
        else if (button.Source.Equals("food.png"))
        {
            fod.TextColor = Colors.Yellow;
        }
        else if (button.Source.Equals("likedislike.png"))
        {
            fav.TextColor = Colors.Yellow;
        }
        else if (button.Source.Equals("travel.png"))
        {
            trav.TextColor = Colors.Yellow;
        }
        else if (button.Source.Equals("basics.png"))
        {
            gret.TextColor = Colors.Yellow;
        }
    }
}
