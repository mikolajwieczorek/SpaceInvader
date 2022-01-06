using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Time range between shooting for an enemy
    [Tooltip("Minimum range of random value for shoot delay")]
    public float minDelay;
    [Tooltip("Maximum range of random value for shoot delay")]
    public float maxDelay;

    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.startMinShootDelay = minDelay;
        GameController.Instance.startMaxShootDelay = maxDelay;

        if (transform.CompareTag("ShootingEnemy"))
            StartCoroutine("ShootDelay");
    }
    
    
    private void ShootDelayReduction() 
    {
        if (minDelay > 2f) 
        {
            minDelay = GameController.Instance.minShootDelay;
            maxDelay = GameController.Instance.maxShootDelay;
        }
    }

	//Recursive function for waiting random amount of seconds and shooting
	IEnumerator ShootDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            BulletPooling.Shoot(transform);
            ShootDelayReduction();
        }
    }
}
