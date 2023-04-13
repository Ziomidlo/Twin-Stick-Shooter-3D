using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData  /// Klasa sluzaca do serializacji danych gry
{
    public float[] position; /// Tablica przechowujaca pozycje obiektu
    public int health; /// Zmienna przechowujaca aktualne zdrowie postaci
    public int score; /// Zmienna przechowujaca aktualny wynik postaci


    public GameData(Character character) /// Konstruktor klasy GameData oraz referencja do obiektu postaci
    {

        score = character.score; ///Przypisanie zmiennej score do pola score obiektu character
        health = character.currentHealth; ///Przypisanie zmiennej health do pola currentHealth obiektu character
        position = new float[3]; ///Przypisanie tablicy pozycji do pozycji obiektu character
        position[0] = character.transform.position.x;
        position[1] = character.transform.position.y;
        position[2] = character.transform.position.z;
    }
}
