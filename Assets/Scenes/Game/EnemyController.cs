using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour ///Klasa obslugujaca zachowanie przeciwnika
{
    public float attackRange = 2f; /// Dystans, po którym przeciwnik bêdzie atakowaæ gracza
    public int damage = 1; /// Iloœæ obra¿eñ, jakie przeciwnik zada graczowi
    public float moveSpeed; /// predkosc przeciwnika
    public Rigidbody myRB; /// stworzenie komponentu Rigidbody dla przeciwnika
    public float stoppingDistance; /// zmienna okreslajaca dystans przy ktorym przciwnik sie zatrzymuje
    private Transform player; /// Klasa Transform pobierajaca polezenie obiektu player
    public int health = 12; /// punkty ¿ycia przeciwnika


    private void Start()
    {
        myRB = GetComponent<Rigidbody>(); /// podbranie komponentu przeciwnika
        player = FindObjectOfType<Character>().transform; /// znajdownanie pozycji gracza
    }
    // Start is called before the first frame update


    private void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed); /// ustawienie predkosci komponentu Rigidbody pomnozony przez wektor kierunku w ktorym jest zwrocony obiekt
    }
    /// Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.position); /// Obliczanie dystansu pomiêdzy przeciwnikiem a graczem

        if (distance <= attackRange) /// Jeœli dystans jest mniejszy ni¿ zadany
        {
            Attack(); /// Wywolaj funkcje Attack
        }
    transform.LookAt(player.transform.position);

        if (health <= 0) /// jeœli punkty ¿ycia spadn¹ do 0 lub poni¿ej
        {
            Die(); /// wywo³aj funkcjê œmierci
        }
    }

    private void Attack() /// Funkcja odpowiadajaca za atak gracza
    {
        player.GetComponent<Character>().TakeDamage(damage); /// Zadaj obrazenia graczowi
    }

    public void TakeDamage(int damage) /// Funckja odpowiadajaca za otrzymywanie obrazen
    {
        health -= damage; /// Odejmij zdrowie od wartosci obrazen

    }

    void Die() ///Funkcja obslugujaca smierc przeciwnika
    {

        Character character = FindObjectOfType<Character>(); ///Pobierz dane z Klasy Character
        character.score += 1; /// Po smierci przeciwnika dodaj punkt graczowi
        Destroy(gameObject); /// Zniszczenie obiektu gry w tym przypadku przeciwnika
    }

        
}
