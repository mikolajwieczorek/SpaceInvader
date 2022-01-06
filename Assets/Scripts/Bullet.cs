using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform bulletPoolParent;

    public Rigidbody2D rb;

	private void Start()
	{
        bulletPoolParent = BulletPooling.tr;
    }

	//Function called every time a bullet gets enabled
	void OnEnable()
    {
        SetBulletProperties();
    }

    //Sets bullet properties according to the parent of a bullet.
    private void SetBulletProperties() 
    {
        transform.position = transform.parent.position;
        
        if (transform.parent.CompareTag("Player"))
        {
            this.gameObject.layer = 7;  //PlayerBullet LayerMask
            Launch(new Vector2(0, 1));
        }else if (transform.parent.CompareTag("ShootingEnemy"))
        {
            this.gameObject.layer = 9;  //EnemyBullet LayerMask
            Launch(new Vector2(0, -1));
        }
        transform.parent = null;
    }

    private void Launch(Vector2 dir) 
    {
        rb.AddForce(dir * 200);
    }

    //Handling collisions 
	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.transform.CompareTag("Player"))
            BulletTouchesPlayer();         //Decreases player's score
        else if (collision.transform.CompareTag("RammingEnemy") || collision.transform.CompareTag("ShootingEnemy"))
            BulletTouchesEnemy(collision.gameObject);    //Kills the enemy


        ResetBullet();  //If bullet touches anything, it gets disabled
	}

    private void BulletTouchesPlayer() 
    {
        GameController.Instance.DecrementScore();
    }

    private void BulletTouchesEnemy(GameObject go) 
    {
        GameController.Instance.IncrementScore();
        Destroy(go);
    }

    //Resetting bullet position and velocity. Also detaches it from actual parent and sets parent as Bullet Pool Object
    private void ResetBullet() 
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(-10, -10);
        transform.SetParent(bulletPoolParent);
        this.gameObject.SetActive(false);
    }
}
