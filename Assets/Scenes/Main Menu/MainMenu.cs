using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour ///klasa menu
{

    public Character character;
    public void Quit() ///metoda menu wychodzenia z gry
    {
        Application.Quit();
    }

    public void LoadGame() ///metoda wczytujaca gre
    {
        SaveSystem.LoadGame();
    }

    public void Load() ///metoda ladujaca scene gry
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
