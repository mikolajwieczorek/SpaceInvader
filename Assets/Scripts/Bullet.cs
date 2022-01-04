using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform bulletPoolParent;

    public Rigidbody2D rb;

    private Vector2 dir = Vector2.zero; //Direction of shooting. For Enemy it's down and for player it's up

	private void Start()
	{
        bulletPoolParent = BulletPooling.tr;
    }

	//Function called every time a bullet gets enabled
	void OnEnable()
    {
        

        SetBulletProperties();

        rb.AddForce(dir * 100);
    }

    //Sets bullet properties according to the parent of a bullet.
    private void SetBulletProperties() 
    {
        transform.position = transform.parent.position;
        
        if (transform.parent.CompareTag("Player"))
        {
            this.gameObject.layer = 7;  //PlayerBullet LayerMask
            dir = new Vector2(0, 1);
        }else if (transform.parent.CompareTag("Enemy"))
        {
            this.gameObject.layer = 9;  //EnemyBullet LayerMask
            dir = new Vector2(0, -1);
        }
    }

    //Handling collisions 
	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.transform.CompareTag("Player"))
            Debug.Log("Touched player");         //Decreases player's score
        else if (collision.transform.CompareTag("Enemy"))
            Debug.Log("Touched Enemy");    //Kills the enemy


        ResetBullet();  //If bullet touches anything, it gets disabled
	}
    
    //Resetting button position and velocity. Also detaches it from actual parent and sets parent as Bullet Pool Object
    private void ResetBullet() 
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(-10, -10);
        transform.SetParent(bulletPoolParent);
        this.gameObject.SetActive(false);
    }
}
