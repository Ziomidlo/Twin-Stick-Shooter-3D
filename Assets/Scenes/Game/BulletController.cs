using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  BulletController : MonoBehaviour  /// Klasa BulletController odpowiada za kontrolowanie pociskow w grze
{

    public float speed;     /// Predkosc pocisku

    public float lifeTime;     /// Czas zycia pocisku

    public int damage = 3;     /// Obra¿enia jakie pocisk zadaje przeciwnikowi


    public void Update() 
    {
        transform.Translate(speed * Vector3.forward * Time.deltaTime); /// Translacja pocisku wzdluz wektora predkosci

        lifeTime -= Time.deltaTime; /// Zmniejszanie zycia pocisku przez deltaTime
        if (lifeTime <= 0) /// Warunek sprawdzajacy czy czas zycia pocisku jest mniejszy lub rowny 0
        {
            Destroy(gameObject); /// Usuniecie pocisku z gry
        }
    }

    private void OnTriggerEnter(Collider other) /// Funkcja OnTriggerEnter odpowiadajaca za obs³uge kolizji z innymi komponentami posiadaj¹cymi ten komponent
    {
        if (other.gameObject.tag == "Enemy") /// Sprawdzenie, czy obiekt na który trafil pocisk ma tag "Enemy"
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>(); /// Pobranie referencji do skryptu EnemyController
            enemy.TakeDamage(damage); ///uzycie metody ze skryptu EnemyController zadajacej obrazenia przeciwnikowi gdy pocisk trafi w przeciwnika
        
            Destroy(gameObject); /// gdy pocisk trafi przeciwnika zostaje zniszczony
        }

    }

}
