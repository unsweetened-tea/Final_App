using Microsoft.Maui.Layouts;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;


namespace Final_App;

public partial class Play : ContentPage
{
    public string difficulty = "";
    public int questionsRemaining = 3;
    public string input = "";

	public Play()
	{
        
        InitializeComponent();
        createWordbankGrid();


    }

    public void difficultyToggle()
    {
        easy.IsVisible = !easy.IsVisible;
        medium.IsVisible = !medium.IsVisible;
        hard.IsVisible = !hard.IsVisible;
    }

    public void answersToggle()
    {
        //responses.IsVisible = !responses.IsVisible;
        bank.IsVisible = !bank.IsVisible;
    }

    private void easy_Clicked(object sender, EventArgs e)
    {
        difficultyToggle();
        difficulty = "easy";
        fillWordbank();
        answersToggle();
        
    }

    private void medium_Clicked(object sender, EventArgs e)
    {
        difficultyToggle();
        difficulty = "medium";
        fillWordbank();
        answersToggle();
        
    }

    private void hard_Clicked(object sender, EventArgs e)
    {
        difficultyToggle();
        difficulty = "hard";
        fillWordbank();
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

    public void createWordbankGrid()
    {
        bank.IsVisible = false;

        for(int x = 0; x < 2; x ++)
        {
            bank.AddRowDefinition(new RowDefinition());
        }

        for (int y = 0; y < 10; y++)
        {
            bank.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star )}); ;
        }


        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var button = new Button
                {
                    Text = "",
                    BackgroundColor = Colors.Blue,
                    FontSize = 20,
                    MaximumHeightRequest = 100,
                    MaximumWidthRequest = 150,
                    TextColor = Colors.Black,
                    Background = Colors.Transparent,
                    BorderColor = Colors.Transparent,

                };
                button.Clicked += Button_Clicked;
                bank.Add(button, j, i);
            }
        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string answer = "";
        if (sender is Button button)
        {
            string buttonText = button.Text;
            if (buttonText != "")
            {
                input = input + buttonText + " ";
                response.Text = input;
            }


            if (difficulty == "easy")
            {
                if (questionsRemaining == 3)
                    answer = family_easy_1_spanish;
                else if (questionsRemaining == 2)
                    answer = family_easy_2_spanish;
                else if (questionsRemaining == 1)
                    answer = family_easy_3_spanish;
            }
            else if (difficulty == "medium")
            {
                if (questionsRemaining == 3)
                    answer = family_medium_1_spanish;
                else if (questionsRemaining == 2)
                    answer = family_medium_2_spanish;
                else if (questionsRemaining == 1)
                    answer = family_medium_3_spanish;
            }
            else if (difficulty == "hard")
            {
                if (questionsRemaining == 3)
                    answer = family_hard_1_spanish;
                else if (questionsRemaining == 2)
                    answer = family_hard_2_spanish;
                else if (questionsRemaining == 1)
                    answer = family_hard_3_spanish;
            }
        }

        if (input.Equals(answer))
        {
            if (questionsRemaining > 0)
            {
                difficultyToggle();
                answersToggle();
            }

            prompt.Text = "Next!";
            response.Text = "";


            for (int i = 0; i < bank.Children.Count; i++)
            {
                var x = bank.Children[i];
                if (x is Button b)
                {
                    b.Text = "";
                }
            }

            input = "";

            questionsRemaining--;

            if (questionsRemaining == 0)
            {
                prompt.Text = "among us?";
                response.Text = "";
                await DisplayAlert("Congrats!", "Return to the home page and try another category (totally done) or repeat this one!", "OK");
                
                await Navigation.PopAsync();

            }
        }

    }

    public void fillWordbank()
    {

        string text = "";
        if (questionsRemaining == 3)
        {
            if (difficulty == "easy")
            {
                text = family_easy_1_spanish;
                prompt.Text = family_easy_1_english;
            }
            else if (difficulty == "medium")
            {
                text = family_medium_1_spanish;
                prompt.Text = family_medium_1_english;
            }
            else if (difficulty == "hard")
            {
                text = family_hard_1_spanish;
                prompt.Text = family_hard_1_english;
            }
        }

        else if (questionsRemaining == 2)
        {
            if (difficulty == "easy")
            {
                text = family_easy_2_spanish;
                prompt.Text = family_easy_2_english;
            }
            else if (difficulty == "medium")
            {
                text = family_medium_2_spanish;
                prompt.Text = family_medium_2_english;
            }
            else if (difficulty == "hard")
            {
                text = family_hard_2_spanish;
                prompt.Text = family_hard_2_english;
            }
        }

        else if (questionsRemaining == 1)
        {
            if (difficulty == "easy")
            {
                text = family_easy_3_spanish;
                prompt.Text = family_easy_3_english;
            }
            else if (difficulty == "medium")
            {
                text = family_medium_3_spanish;
                prompt.Text = family_medium_3_english;
            }
            else if (difficulty == "hard")
            {
                text = family_hard_3_spanish;
                prompt.Text = family_hard_3_english;
            }
        }




        string[] words = text.Split(' ');

        Random random = new Random();
        int n = words.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            string temp = words[i];
            words[i] = words[j];
            words[j] = temp;
        }


        for (int i = 0; i < words.Length; i++)
        {
            var x = bank.Children[i];
            if(x is Button button)
            {
                button.Text = words[i];
            }
        }



        
    }

    // add space at end of spanish sentences
    private string family_easy_1_spanish = "Mi hermana ";
    private string family_easy_2_spanish = "Mi pap� ";
    private string family_easy_3_spanish = "Mi abuela ";

    private string family_medium_1_spanish = "Mi hermana es inteligente ";
    private string family_medium_2_spanish = "Mi pap� es simpatico ";
    private string family_medium_3_spanish = "Mi abuela es bonita ";

    private string family_hard_1_spanish = "Mi hermana y yo jugamos juntas en la casa ";
    private string family_hard_2_spanish = "Mi pap� me ayuda con la tarea ";
    private string family_hard_3_spanish = "Mi abuela cuenta cuentos antes de dormir ";


    private string family_easy_1_english = "My sister";
    private string family_easy_2_english = "My dad";
    private string family_easy_3_english = "My grandma";

    private string family_medium_1_english = "My sister is smart";
    private string family_medium_2_english = "My dad is nice";
    private string family_medium_3_english = "My grandma is pretty";

    private string family_hard_1_english = "My sister and I play together at home";
    private string family_hard_2_english = "My dad helps me with homework";
    private string family_hard_3_english = "My grandmother tells stories before bedtime";


    private string food_easy_1_spanish = "La pizza ";
    private string food_easy_2_spanish = "La fruta ";
    private string food_easy_3_spanish = "El arroz ";

    private string food_medium_1_spanish = "Me gusta pizza ";
    private string food_medium_2_spanish = "La fruta es fresca ";
    private string food_medium_3_spanish = "Me encanta el helado ";

    private string food_hard_1_spanish = "Me gusta la pizza con queso y pepperoni ";
    private string food_hard_2_spanish = "La fruta es fresca y saludable para merendar ";
    private string food_hard_3_spanish = "El arroz con pollo es mi plato favorito ";

}