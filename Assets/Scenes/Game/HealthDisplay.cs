using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour /// Klasa odpowiadajaca za wyswietlanie zdrowia gracza
{

    private TextMesh healthText; /// Zmienna healthText odpowiada za tekst wyswietlajacy wynik

    void Start()
    {
        healthText = GetComponent<TextMesh>(); /// Pobranie komponentu TextMesh i przypisanie do zmiennej healthText
    }

    public void UpdateHealth(int health) /// Funkcja UpdateHealth jest wywolywana aby zaktualizowac zdrowie w grze
    {
        healthText.text = "Health: " + health.ToString(); /// Zmiana tekstu w healthText na "Health: " + wartosc health
    }

}
