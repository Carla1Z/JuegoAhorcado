﻿using System.ComponentModel;
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
        "computadora",
        "programacion",
        "elefante",
        "chocolate",
        "telefono",
        "avion",
        "montaña",
        "felicidad",
        "escuela",
        "biblioteca",
        "mariposa",
        "guitarra",
        "feliz",
        "viaje",
        "fotografia",
        "jugador",
        "universo",
        "pizza",
        "helado"
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
        Letters.AddRange("abcdefghijklmnñopqrstuvwxyz");
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

    private void Button_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if(btn != null)
        {
            var letter = btn.Text;
            btn.IsEnabled = false;
            HandleGuess(letter[0]);
        }
    }

    private void HandleGuess(char letter)
    {
        if(guessed.IndexOf(letter) == -1)
        {
            guessed.Add(letter);
        }
        if(answer.IndexOf(letter) >= 0)
        {
            CalculateWord(answer, guessed);
            CheckIfGameWon();
        }
        else if (answer.IndexOf(letter) == -1)
        {
            mistakes++;
            UpdateStatus();
            CheckIfGameLost();
            CurrentImage = $"img{mistakes}.jpg";
        }
    }

    private void CheckIfGameLost()
    {
       if (mistakes == maxWrong)
        {
            Message = "Perdiste!";
            DisableLetters();
        }
    }

    private void DisableLetters()
    {
        foreach (var children in LettersContainer.Children)
        {
            var btn = children as Button;
            if(btn != null )
            {
                btn.IsEnabled = false;
            }
        }
    }

    private void EnableLetters()
    {
        foreach (var children in LettersContainer.Children)
        {
            var btn = children as Button;
            if (btn != null)
            {
                btn.IsEnabled = true;
            }
        }
    }

    private void CheckIfGameWon()
    {
        if (spotlight.Replace(" ", "") == answer)
        {
            Message = "Ganaste!";
            DisableLetters();
        }
    }

    private void UpdateStatus()
    {
        GameStatus = $"Nro. Errores: {mistakes} de {maxWrong}.";
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        mistakes = 0 ;
        guessed = new List<char> ();
        CurrentImage = "img0.jpg";
        PickWord();
        CalculateWord(answer,guessed);
        Message = "";
        UpdateStatus();
        EnableLetters();
    }
}

