namespace Final_App;
using System.IO;
using static FamilyData;

public partial class PlaceholderPractice : ContentPage
{
    Dictionary<String, String> easy;
    Dictionary<String, String> medium;
    Dictionary<String, String> hard;
    Dictionary<string, string> sentences;
    int curIndex;
    bool englishRevealed;
    public PlaceholderPractice(string topic)
      {
            InitializeComponent();
        InitializeSentences(topic);
        sentences = easy;
        curIndex = 0;
        englishRevealed = false;
        //DisplayAlert("sentences", sentences.Count.ToString(), "ok");
        updateFlashcard();

      }

    void InitializeSentences(string topic)
    {
        topic = topic.ToLower();
        switch (topic)
        {
            case "family":
               
                easy = readSentences("family_easy");
                medium = readSentences("family_medium");
                hard = readSentences("family_hard");
                break; // Add break to prevent fall-through
            case "greetings":
                easy = readSentences("Resources/Sentences/greetings_easy.txt"); // Adjust the paths for greetings
                medium = readSentences("Resources/Sentences/greetings_medium.txt");
                hard = readSentences("Resources/Sentences/greetings_hard.txt");
                break; // Add break here as well
            default:
                // For any other topic, use default values or handle accordingly
                easy = readSentences("Resources/Sentences/default_easy.txt");
                medium = readSentences("Resources/Sentences/default_medium.txt");
                hard = readSentences("Resources/Sentences/default_hard.txt");
                break; // Add break for the default case
        }
    }


    void rightButton_Clicked(System.Object sender, System.EventArgs e)
    {
        leftButton.IsEnabled = true;
        curIndex++;
        if (curIndex == sentences.Count - 1) rightButton.IsEnabled = false;
        else if (curIndex > sentences.Count - 1)
        {
            curIndex = sentences.Count - 1;
            rightButton.IsEnabled = false;
        }
        updateFlashcard();
    }

    void leftButton_Clicked(System.Object sender, System.EventArgs e)
    {
        rightButton.IsEnabled = true;
        curIndex--;
        if (curIndex == 0) leftButton.IsEnabled = false;
        else if (curIndex < 0)
        {
            curIndex = 0;
            leftButton.IsEnabled = false;
        }
        updateFlashcard();

    }

    void flashcard_Clicked(System.Object sender, System.EventArgs e)
    {
        if (englishRevealed) {
            cardText.Text = sentences.ElementAt(curIndex).Key;
            englishRevealed = false;
        } else
        {
            cardText.Text = sentences.ElementAt(curIndex).Value;
            englishRevealed = true;
        }
    }

    void updateFlashcard()
    {
        if (englishRevealed)
            cardText.Text = sentences.ElementAt(curIndex).Value;
        else
            cardText.Text = sentences.ElementAt(curIndex).Key;
    }

    Dictionary<string, string> readSentences(string filename) {
        List<string> english = new List<string>();
        List<string> spanish = new List<string>();
        var count = 0;
        Dictionary<string, string> translations = new Dictionary<string, string>();
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            //Read the first line of text
            if (filename.Equals("family_easy"))
            {
                spanish = SpanishListEasy;
                english = EnglishListEasy;
            } else if (filename.Equals("family_medium"))
            {
                spanish = SpanishListMedium;
                english = SpanishListMedium;
            } else if (filename.Equals("family_hard"))
            {
                spanish = SpanishListHard;
                english = SpanishListHard;
            }

            for (int i = 0; i < spanish.Count; i++)
            {
                translations.Add(english[i], spanish[i]);
            }
        }
        catch (Exception e)
        {
            DisplayAlert("Exception", e.Message, "ok");
            Console.WriteLine("Exception: " + e.Message);
        }
        return translations;
    }

    void difficultyButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var button = sender as ImageButton;
        if (button.Source == easyButton.Source)
        {
            sentences = easy;
            curIndex = 0;
            englishRevealed = false;
        } else if (button.Source == mediumButton.Source)
        {
            sentences = medium;
            curIndex = 0;
            englishRevealed = false;
        } else
        {
            sentences = hard;
            curIndex = 0;
            englishRevealed = false;
        }
    }
}
