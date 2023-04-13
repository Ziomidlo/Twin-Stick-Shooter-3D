using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour ///Klasa obslugujaca zachowanie postaci gry oraz obsluge przyciskow klawiatury oraz myszy
{

    public GunController gun; /// Kontroler broni
    public Rigidbody rb; /// Stworzenie komponentu Rigdbody dla bohatera
    public float movementSpeed = 6f; /// Predkosc poruszania
    public float RotateSpeed = 2f; /// Predkosc obrotu
    public int maxHealth = 100; /// Maksymalne zdrowie
    public int currentHealth; /// Obecne zdrowie
    public int score = 0; /// Wynik
    public ScoreDisplay scoreDisplay; /// Komponent wyswietlaj¹cy wynik
    public HealthDisplay healthDisplay; /// Komponent wyswietlaj¹cy zdrowie

    void Start()
    {
        currentHealth = maxHealth; /// przypisanie przy pierwszej klatce maksymalnego zdrowia
        
    }

    public void SaveGame() /// Funkcja zapisujaca gre
    {
        SaveSystem.SaveGame(this); 
    }

    public void LoadGame() ///Funkcja wczytujaca stan gry, pobiera wynik, zdrowie oraz pozycje postaci
    {
        GameData data = SaveSystem.LoadGame();

        score = data.score;
        currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }


    public void TakeDamage(int damage) ///Funkcja powoduj¹ca otrzymanie obrazen
    {
        currentHealth -= damage; ///Odejmowanie obecnego zdrowia o zadane obrazenia
        if (currentHealth <= 0) /// Gdy zdrowie jest rowne lub mniejsze od 0 
        {
            Die(); ///Wywolaj funkcje odpowiadajaca za smierc postaci
        }
    }

    void Die() /// Funkcja powodujaca smierc postaci
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single); /// zaladuj scene Main Menu
    }


    // Update is called once per frame  
    public void Update() /// Funkcja update wykonwana raz na jedna klatke
    {
        if (Input.GetKey(KeyCode.W)) ///Gdy zostanie wcisniety przycisk W, przesun postac o wektor w przod z okreslona predkoscia
        {
            this.transform.Translate(movementSpeed * Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) ///Gdy zostanie wcisniety przycisk S, przesun postac o wektor w tyl z okreslona predkoscia
        {
            this.transform.Translate(movementSpeed * Vector3.back * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)) ///Gdy zostanie wcisniety przycisk A, przesun postac o wektor w lewo z okreslona predkoscia
        {
            this.transform.Translate(movementSpeed * Vector3.left * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) ///Gdy zostanie wcisniety przycisk D, przesun postac o wektor w prawo z okreslona predkoscia
        {
            this.transform.Translate(movementSpeed * Vector3.right * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E)) ///Gdy zostanie wcisniety przycisk E, obroc postac o wektor z okreslona predkoscia rotacji
        {
            transform.localRotation *= Quaternion.AngleAxis(RotateSpeed, Vector3.up);
        }

        else if (Input.GetKey(KeyCode.Q)) ///Gdy zostanie wcisniety przycisk Q, obroc postac o wektor z okreslona predkoscia rotacji
        {
            transform.localRotation *= Quaternion.AngleAxis(-RotateSpeed, Vector3.up);
        }

        if (Input.GetMouseButtonDown(0)) ///Gdy lewy przycisk myszy jest nacisniety, ustaw wlasciwosc strzelania z broni na true
        {
            gun.isFiring = true;
        }

        if (Input.GetMouseButtonUp(0)) ///Gdy lewy przycisk myszy nie jest nacisniety, ustaw wlasciwosc strzelania z broni na false
        {
            gun.isFiring = false;
        }

        if (Input.GetKey(KeyCode.Escape)) /// Po nacisnieciu przycisku Escape zaladuj scene main menu
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }

        if (Input.GetKey(KeyCode.Z)) /// Po nacisnieciu przycisku Z, wywolaj funckje zapisujaca gre
        {
            SaveGame();
        }

        if (Input.GetKey(KeyCode.X)) /// Po nacisnieciu przycisku X, wywolaj funkcje wczytujaca gre
        {
            LoadGame();
        }

        scoreDisplay.UpdateScore(score); /// Wywolanie funkcji UpdateScore z klasy ScoreDisplay w celu aktualizacji wyniku
        healthDisplay.UpdateHealth(currentHealth); /// Wywloanie funkcji UpdateHealth z klasy HealthDisplay w celu aktualizacji zdrowia

    }
}
