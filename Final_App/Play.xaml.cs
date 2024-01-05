using Bumptech.Glide.Load.Resource.Gif;

namespace Final_App;

public partial class Play : ContentPage
{
    public string difficulty = "";
    public int questionsRemaining = 10;
	public Play()
	{
		InitializeComponent();
        createWordbackGrid();
	}

    public void difficultyToggle()
    {
        easy.IsVisible = !easy.IsVisible;
        medium.IsVisible = !medium.IsVisible;
        hard.IsVisible = !hard.IsVisible;
    }

    public void answersToggle()
    {
        responses.IsVisible = !responses.IsVisible;
    }

    private void easy_Clicked(object sender, EventArgs e)
    {
        difficultyToggle();
        difficulty = "easy";
        answersToggle();
    }

    private void medium_Clicked(object sender, EventArgs e)
    {
        difficultyToggle();
        difficulty = "medium";
        answersToggle();
    }

    private void hard_Clicked(object sender, EventArgs e)
    {
        difficultyToggle();
        difficulty = "hard";
        answersToggle();
    }



    private void answer_1_Clicked(object sender, EventArgs e)
    {
        // check if answer is right

        // check if there are questions left
        if (questionsRemaining > 0) 
        {
            difficultyToggle();
            answersToggle();
        }
    }

    private void answer_2_Clicked(object sender, EventArgs e)
    {
        // check if answer is right

        // check if there are questions left
        if (questionsRemaining > 0)
        {
            difficultyToggle();
            answersToggle();
        }
    }

    private void answer_3_Clicked(object sender, EventArgs e)
    {
        // check if answer is right

        // check if there are questions left
        if (questionsRemaining > 0)
        {
            difficultyToggle();
            answersToggle();
        }
    }

    private void answer_4_Clicked(object sender, EventArgs e)
    {
        // check if answer is right

        // check if there are questions left
        if (questionsRemaining > 0)
        {
            difficultyToggle();
            answersToggle();
        }
    }

    public void createWordbackGrid()
    {
        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition {Height = new GridLength(100)},
                new RowDefinition {Height = new GridLength(100)}
            },

        };



        for (int i = 0; i < 40; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }
    }

    public void fillWordbank()
    {

    }


}