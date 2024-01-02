namespace Final_App;
using System.IO;

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
        Console.WriteLine(sentences.Count.ToString());
        //DisplayAlert("sentences", sentences.Count.ToString(), "ok");
        //updateFlashcard();

	}

    void InitializeSentences(string topic)
    {
        topic = topic.ToLower();
        switch (topic)
        {
            case "family":
                
                easy = readSentences("Resources/Raw/family_easy.txt");
                medium = readSentences("Raw/family_medium.txt");
                hard = readSentences("Final_App/Resources/Raw/family_hard.txt");
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
        String english = "";
        var spanish = "";
        var count = 0;
        Dictionary<string, string> translations = new Dictionary<string, string>();
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filename);
            //Read the first line of text

            if (count % 2 == 0)
            {
                spanish = sr.ReadLine();
                DisplayAlert("sentences", "hi", "ok");
            }
            else
                english = sr.ReadLine();
            //Continue to read until you reach end of file
            while (spanish != null)
            {
                count++;
                if (count % 2 == 0)
                {

                    spanish = sr.ReadLine();
                }
                else
                {
                    english = sr.ReadLine();
                    translations.Add(spanish, english.Substring(1, english.Length - 2));
                    
                }
            }
            //close the file
            sr.Close();
        }
        catch (Exception e)
        {
            DisplayAlert("Exception", e.Message, "ok");
            Console.WriteLine("Exception: " + e.Message);
        }
        return translations;
    }
}