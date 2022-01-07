using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private int shootDelay = 2;

    public float moveSpeed;     //Player move speed
    private float dir;    //Player moving direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("ShootDelay");
    }

	private void Update()
	{
        MovingDirection((int)Input.GetAxisRaw("Horizontal"));
        if (GameController.Instance.isBoostActive)
            shootDelay = 1;
        else
            shootDelay = 2;
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
            yield return new WaitForSeconds(shootDelay);
            BulletPooling.Shoot(transform);
        } 
    }
}
