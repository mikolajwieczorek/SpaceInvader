using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShootDelay");
    }

    //Recursive function for waiting random amount of seconds and shooting
    IEnumerator ShootDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4, 7));
            BulletPooling.Shoot(transform);
        }
    }
}
