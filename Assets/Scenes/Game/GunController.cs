using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour /// Klasa odpowiadajca za dzialanie broni
{

    public bool isFiring; ///Zmienna okreslajaca czy bron strzela

    public BulletController bullet; /// Prefab pocisku
    public float bulletSpeed; /// Zmienna okreslajaca predkosc pocisku
    public float timeBetweenShots; ///Zmienna okreslajaca czas pomiedzy strzalami
    private float shotCounter; /// Zmeinna pomocnicza do odliczania czasu pomiedzy strzalami

    public Transform firePoint; ///Okreslenie pozycji z ktorej strzelamy

    // Update is called once per frame
    void Update()
    {

        if(isFiring) ///Jesli bron strzela
        {
            shotCounter -= Time.deltaTime; ///  odliczanie czasu pomiedzy strzalami
            if(shotCounter <= 0) ///Jezeli odliczony czas jest mniejszy lub rowny 0 to
            {
                shotCounter = timeBetweenShots; ///Zresteuj odliczenie czasu
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation); ///Stworz nowy pocisk
                newBullet.speed = bulletSpeed; ///Ustaw predkosc pocisku
            }
        } else
        {
            shotCounter = 0; ///Jesli bron nie strzela zresetuj odliczanie strzalu
        }
    }
}
