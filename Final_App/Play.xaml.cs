using Microsoft.Maui.Layouts;
using Microsoft.Maui.Controls;


namespace Final_App;

public partial class Play : ContentPage
{
    public string difficulty = "";
    public int questionsRemaining = 3;
    public Grid bank;
	public Play()
	{
        
        InitializeComponent();
        createWordbankGrid();
        fillWordbank();
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
        fillWordbank();
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

    public void createWordbankGrid()
    {
        //var myGrid = new Grid();

        //// Define rows and columns
        //myGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        //myGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });

        //myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        //myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

        //var coloredBox = new BoxView
        //{
        //    Color = Colors.Red // Set your desired color
        //};
        //myGrid.Add(coloredBox, 0, 0); // Column 0, Row 0

        //var anotherColoredBox = new BoxView
        //{
        //    Color = Colors.Blue // Set your desired color
        //};
        //myGrid.Add(anotherColoredBox, 1, 1); // Column 1, Row 1

        //var myLabel = new Label
        //{
        //    Text = "Hello, MAUI!",
        //    FontSize = 20
        //};
        //myGrid.Add(myLabel, 0, 1); // Column 0, Row 1, Spanning 2 rows

        //// Add the Grid to the content of the page
        //Content = myGrid;

        bank = new Grid()
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(100) },
                new RowDefinition { Height = new GridLength(100) }
            },

            
        };

        for (int i = 0; i < 2; i++)
        {
            bank.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        AbsoluteLayout.SetLayoutBounds(bank, new Rect(0.5, 0.6, 0.9, 250));
        AbsoluteLayout.SetLayoutFlags(bank, AbsoluteLayoutFlags.WidthProportional);
        AbsoluteLayout.SetLayoutFlags(bank, AbsoluteLayoutFlags.PositionProportional);

        

        bank.BackgroundColor = Colors.Purple;

        Content = bank;

    }

    public void fillWordbank()
    {
        string test = "This is a test string la la la la la la";
        string[] words = test.Split(' ');


        for (int i = 0;i < words.Length;i++) 
        {
            //var button = new Button
            //{
            //    Text = words[i],
            //    FontSize = 20,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,
            //    HeightRequest = 100,
            //    WidthRequest = 100,
            //};

            bank.Add(new BoxView
            {
                Color = Colors.Purple
            }, 1, 1);
        }



        
    }

    private string family_easy_1_spanish = "Mi hermana";
    private string family_easy_2_spanish = "Mi papá";
    private string family_easy_3_spanish = "Mi abuela";

    private string family_medium_1_spanish = "Mi hermana es inteligente";
    private string family_medium_2_spanish = "Mi papá es simpatico";
    private string family_medium_3_spanish = "Mi abuela es bonita";

    private string family_hard_1_spanish = "Mi hermana y yo jugamos juntas en la casa";
    private string family_hard_2_spanish = "Mi papá me ayuda con la tarea";
    private string family_hard_3_spanish = "Mi abuela cuenta cuentos antes de dormir";


    private string family_easy_1_english = "My sister";
    private string family_easy_2_english = "My dad";
    private string family_easy_3_english = "My grandma";

    private string family_medium_1_english = "My sister is smart";
    private string family_medium_2_english = "My dad is nice";
    private string family_medium_3_english = "My grandma is pretty";

    private string family_hard_1_english = "My sister and I play together at home";
    private string family_hard_2_english = "My dad helps me with homework";
    private string family_hard_3_english = "My grandmother tells stories before bedtime";


    private string food_easy_1_spanish = "La pizza";
    private string food_easy_2_spanish = "La fruta";
    private string food_easy_3_spanish = "El arroz";

    private string food_medium_1_spanish = "Me gusta pizza";
    private string food_medium_2_spanish = "La fruta es fresca";
    private string food_medium_3_spanish = "Me encanta el helado";

    private string food_hard_1_spanish = "Me gusta la pizza con queso y pepperoni";
    private string food_hard_2_spanish = "La fruta es fresca y saludable para merendar";
    private string food_hard_3_spanish = "El arroz con pollo es mi plato favorito";

}