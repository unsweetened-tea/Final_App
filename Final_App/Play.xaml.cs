namespace Final_App;

public partial class Play : ContentPage
{
    public string difficulty = "";
    public int questionsRemaining = 10;
	public Play()
	{
		InitializeComponent();
	}

    public void difficultyToggle()
    {
        easy.IsVisible = !easy.IsVisible;
        medium.IsVisible = !medium.IsVisible;
        hard.IsVisible = !hard.IsVisible;
    }

    public void answersToggle()
    {
        answer_1.IsVisible = !answer_1.IsVisible;
        answer_2.IsVisible = !answer_2.IsVisible;
        answer_3.IsVisible = !answer_3.IsVisible;
        answer_4.IsVisible = !answer_4.IsVisible;
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


}