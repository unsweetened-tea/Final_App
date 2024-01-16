using Microsoft.Maui.Layouts;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
//using Metal;


namespace Final_App;

public partial class Play : ContentPage
{
    public string difficulty = "";
    public string selectedCategory = "";
    public int questionsRemaining = 3;
   
    public string input = "";

    public string[] categories = {"family", "food", "favorites", "travel", "greetings" };
    Dictionary<(string, string), List<Question>> questions = new Dictionary<(string, string), List<Question>>();

    private int numCategories = 5;

    Question currentQuestion = new Question();

    public HomePage home = new HomePage();

    public ObservableCollection<Weapon> weaponsUsed;

    public ObservableCollection<Skin> skins;

    ObservableCollection<Weapon> weapons;

    public Play(string category)
	{
        selectedCategory = category;
        InitializeComponent();
        loadQuestions();
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
        delete.IsVisible = !delete.IsVisible;
        
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

    public void createWordbankGrid()
    {
        bank.IsVisible = false;

        for(int x = 0; x < 2; x ++)
        {
            bank.AddRowDefinition(new RowDefinition());
        }

        for (int y = 0; y < 10; y++)
        {
            bank.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto )}); ;
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
                    MaximumWidthRequest = 200,
                    TextColor = Colors.Black,
                    Background = Colors.Transparent,
                    BorderColor = Colors.Transparent,

                };
                button.Clicked += Button_Clicked;
                bank.Add(button, j, i);
            }
        }

    }

    public void loadQuestions()
    {

        //base code generated by chatgpt
        string familyPath = "Resources\\familyQuestions.txt";
        string foodPath = "Resources\\foodQuestions.txt";
        string travelPath = "Resources\\travelQuestions.txt";
        string favoritesPath = "Resources\\favoriteQuestions.txt";
        string greetingsPath = "Resources\\greetingQuestions.txt";


        // Specify the string to search for
        string easybreak = "EASYBREAK";
        string medbreak = "MEDBREAK";
        string hardbreak = "HARDBREAK";


        // makes  dict of file paths
        var fileDict = new Dictionary<string, string>();
        fileDict.Add("family", familyPath);
        fileDict.Add("food", foodPath);
        fileDict.Add("travel", travelPath);
        fileDict.Add("greetings", greetingsPath);
        fileDict.Add("favorites", favoritesPath);


        // loads questions into dict with key "category, difficulty"
        using (StreamReader reader = new StreamReader(fileDict[selectedCategory]))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Check for the first string
                if (line.Contains(easybreak))
                {

                    questions.Add((selectedCategory, "easy"), new List<Question>());

                    while ((line = reader.ReadLine()) != null)
                    {

                        if (line.Contains(medbreak))
                        {

                            questions.Add((selectedCategory, "medium"), new List<Question>());

                            while ((line = reader.ReadLine()) != null)
                            {

                                if (line.Contains(hardbreak))
                                {

                                    questions.Add((selectedCategory, "hard"), new List<Question>());

                                    while ((line = reader.ReadLine()) != null)
                                    {
                                        questions[(selectedCategory, "hard")].Add(new Question(selectedCategory, "hard",
                                            line, reader.ReadLine()));
                                    }

                                    break;
                                }

                                questions[(selectedCategory, "medium")].Add(new Question(selectedCategory, "medium",
                                    line, reader.ReadLine()));
                            }
                            break;
                        }

                        questions[(selectedCategory, "easy")].Add(new Question(selectedCategory, "easy",
                            line, reader.ReadLine()));
                    }
                    break;
                }
            }

        }

    }

    // when text button clicked
    private async void Button_Clicked(object sender, EventArgs e)
    {
        Random rand = new Random();

        string answer = currentQuestion.spanish;
        if (sender is Button button)
        {
            string buttonText = button.Text;
            if (buttonText != "")
            {
                input = input + buttonText + " ";
                response.Text = input;
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
                prompt.Text = "sussy among us?";
                response.Text = "";
                await DisplayAlert("Congrats!", "Return to the home page and try another category or repeat this one!", "OK");
                
                await Navigation.PopAsync();

            }
        }

        Console.WriteLine(input);

    }

    // fills word bacnk with spanish words and shuffles them up
    public void fillWordbank()
    {
        Random rand = new Random();

        if (difficulty == "easy")
        {
            currentQuestion = questions[(selectedCategory, "easy")][rand.Next(0, questions[(selectedCategory, "easy")].Count())];
        }
        else if (difficulty == "medium")
        {
            currentQuestion = questions[(selectedCategory, "medium")][rand.Next(0, questions[(selectedCategory, "medium")].Count())];
        }
        else if (difficulty == "hard")
        {
            currentQuestion = questions[(selectedCategory, "hard")][rand.Next(0, questions[(selectedCategory, "hard")].Count())];
        }


        string text = "";
        text = currentQuestion.spanish;
        prompt.Text = currentQuestion.english;

        string[] wordspre = text.Split(' ');
        string[] words = wordspre.Take(wordspre.Length - 1).ToArray();

        // remove empty nothing from end

        Random random = new Random();
        int n = words.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i);
            string temp = words[i];
            words[i] = words[j];
            words[j] = temp;
        }


        for (int i = 0; i < words.Length; i++)
        {
            var x = bank.Children[i];
            if(x is Button button)
            {
                if (words[i] != "")
                    button.Text = words[i];
            }
        }



        
    }

    // acts like a backspace
    private void delete_Clicked(object sender, EventArgs e)
    {
        string[] list = input.Split(" ");
        string newstr = "";
        if (list.Length != 0)
        {
            string[] newlist = list.Take(list.Length - 2).ToArray();
            newstr = string.Join(" ", newlist) + " ";

        }
        if (newstr.Equals(" "))
        {
            newstr = "";
        }

        input = newstr;
        response.Text = input;
    }

}