using System.ComponentModel;
using System.Diagnostics;

namespace JuegoAhorcado;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
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
        PickWord();
    }

    #region Game Engine
    private void PickWord()
    {
        answer =
             words[new Random().Next(0, words.Count)];
        Debug.WriteLine(answer);
    }

    #endregion


}

