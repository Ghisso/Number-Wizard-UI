using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour {

    int guess;
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] TextMeshProUGUI quotesComponent;
    [SerializeField] Button higher;
    [SerializeField] Button lower;
    string[] quotes = { "Why couldn't I read you?!",
                        "You are powerful indeed! But I know your weak point!",
                        "No!! It cannot be!! Noo!",
                        "I can't read you!",
                        "I will get you this time!",
                        "It is but a momentary lapse in my powers!",
                        "Damn Protoss and their Khala messing with the psychic energies!",
                        "I will crush you!",
                        "I smell magic in the air! Oops I meant psychosis...",
                        "Abra Kadabra! Slightly different from that of He-Who-Must-Not-Be-Named!"};
    string victoryQuote = "Hahaha I got you now!";

    void Start()
    {
        higher.interactable = true;
        lower.interactable = true;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max+1);
        textComponent.text = guess.ToString();
    }

    public void OnPressLower()
    {
        if (guess == min)
        {
            max = guess;
        }
        else
        {
            max = guess - 1;
        }

        NextGuess();
        quotesComponent.text = quotes[Random.Range(0, quotes.Length)];

        if (min == max)
        {
            higher.interactable = false;
            lower.interactable = false;
            quotesComponent.text = victoryQuote;
        }  
    }

    public void OnPressHigher()
    {
        if (guess == max)
        {
            min = guess;
        }
        else
        {
            min = guess + 1;
        }

        NextGuess();
        quotesComponent.text = quotes[Random.Range(0, quotes.Length)];

        if (min == max)
        {
            higher.interactable = false;
            lower.interactable = false;
            quotesComponent.text = victoryQuote;
        }
    }
}
