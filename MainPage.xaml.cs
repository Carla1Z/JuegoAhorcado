using System.ComponentModel;
using System.Diagnostics;

namespace JuegoAhorcado;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    #region UI Properties
    public string Spotlight
    {
        get => spotlight;
        set
        {
            spotlight = value;
            OnPropertyChanged();
        }
    }
    public List<char> Letters
    {
        get => letters;
        set
        {
            letters = value;
            OnPropertyChanged();
        }
    }

    public string Message
    {
        get => message;
        set
        {
            message = value;
            OnPropertyChanged();
        }
    }
    public string GameStatus
    {
        get => gameStatus;
        set
        {
            gameStatus = value;
            OnPropertyChanged();
        }
    }
    public string CurrentImage
    {
        get => currentImage;
        set
        {
            currentImage = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Fields
    List<string> words = new List<string>()
    {
        "Computadora",
        "Programación",
        "Elefante",
        "Chocolate",
        "Teléfono",
        "Avión",
        "Montaña",
        "Felicidad",
        "Escuela",
        "Biblioteca",
        "Mariposa",
        "Guitarra",
        "Feliz",
        "Viaje",
        "Fotografía",
        "Jugador",
        "Universo",
        "Pizza",
        "Helado"
    };
    string answer = "";
    private string spotlight;
    List<char> guessed = new List<char>();
    private List<char> letters = new List<char>();
    private string message;
    int mistakes = 0;
    int maxWrong = 6;
    private string gameStatus;
    private string currentImage = "img0.jpg";
    #endregion
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        PickWord();
        CalculateWord(answer, guessed);
    }

    #region Game Engine
    private void PickWord()
    {
        answer =
             words[new Random().Next(0, words.Count)];
        Debug.WriteLine(answer);
    }

    private void CalculateWord(string answer, List<char> guessed)
    {
        var temp =
             answer.Select(x => (guessed.IndexOf(x) >= 0 ? x : '_'))
             .ToArray();
        Spotlight = string.Join(' ', temp);
    }

    #endregion


}

