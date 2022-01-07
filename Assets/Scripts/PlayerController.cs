using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;     //Player move speed
    private float dir;    //Player moving direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("ShootDelay");
    }

	private void Update()
	{
        //MovingDirection(Input.GetAxisRaw("Horizontal"));
            
	}

	void FixedUpdate()
    {
        rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
    }

    public void MovingDirection(int direction) 
    {
        dir = direction;
    }

    //Recursive function for waiting 2 seconds and shooting
    IEnumerator ShootDelay()
    {
        while (true)
        { 
            yield return new WaitForSeconds(2);
            BulletPooling.Shoot(transform);
        } 
    }
}
