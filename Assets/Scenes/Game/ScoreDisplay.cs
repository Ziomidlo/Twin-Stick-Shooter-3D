using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour /// Klasa odpowiadajaca za wyswietlanie wyniku gracza
{
    private TextMesh scoreText; /// Zmienna scoreText odpowiada za tekst wyswietlajacy wynik

    void Start()
    {
        scoreText = GetComponent<TextMesh>(); /// Pobranie komponentu TextMesh i przypisanie do zmiennej scoreText
    } 

    public void UpdateScore(int score) /// Funkcja UpdateScore jest wywolywana aby zaktualizowac wynik w grze
    {
        scoreText.text = "Score: " + score.ToString(); /// Zmiana tekstu w scoreText na "Score: " + wartosc score
    }

}

