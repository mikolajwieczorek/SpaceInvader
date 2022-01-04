using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public static Transform tr; //Pool object transform. Other script is using it to set parent.

    private static GameObject[] bulletPool = new GameObject[5]; //Array of bullets
    public GameObject bulletPrefab;

    private Vector2 bulletPoolPosition = new Vector2(-10, -10);

    public static int bulletsAmount = 5;
    private static int actualBullet;    //indicates the next bullet that will be shot

    void Start()
    {
        tr = GetComponent<Transform>();
        actualBullet = 0;

        //Simply creating desired amount of bullets and assigning them to the array
        for (int i = 0; i < bulletsAmount; i++) 
        {
            bulletPool[i] = (GameObject)Instantiate(bulletPrefab, bulletPoolPosition, Quaternion.identity, this.transform);
            bulletPool[i].SetActive(false);
        }
    }

    //Setting up the next bullet to be shot
    private static void IncrementActualBullet() 
    {
        actualBullet++;
        if (actualBullet >= bulletsAmount)
            actualBullet = 0;
    }

    //Preparing a bullet to be launched by a player or an opponent
    //It uses the given Transform to set the parent of a bullet
    public static void Shoot(Transform parent)
    {
        bulletPool[actualBullet].transform.SetParent(parent);
        
        bulletPool[actualBullet].SetActive(true);
        IncrementActualBullet();
    }
}
