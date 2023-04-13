using UnityEngine;

public class EnemySpawner : MonoBehaviour ///Klasa odpowiadajaca za odradzanie sie przeciwnikow
{
    public GameObject enemyPrefab; ///Inicjacja prefabu przeciwnika
    public GameObject enemyPrefab1; /// Inicjacja drugiego prefabu przeciwnika
    public float spawnTime = 5f; /// Pole okreslajace co ile sekund bedzie spawn przeciwnika

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTime); /// Powtarzajace sie wywolanie metody RespawnEnemy na starcie gry z opoznieniem 0 sekund i wykonane pozniej co 5 sekund
    }

    private void SpawnEnemy() /// Funkcja odpowiedzialna za respawn przeciwnikow
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)); ///Okreslenie losowej pozycji respawnu dla przeciwnika
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); /// Stworzenie przeciwnika za pomoca funkcji Instantiate dla pierwszego prafabu i dla losowej pozycji

        Vector3 spawnPosition1 = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)); ///Okreslenie losowej pozycji respawnu dla przeciwnika
        Instantiate(enemyPrefab1, spawnPosition1, Quaternion.identity); /// Stworzenie przeciwnika za pomoca funkcji Instantiate dla drugiego prafabu i dla losowej pozycji

    }
}