using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void FixedUpdate()
    {
        dir = Input.GetAxisRaw("Horizontal") * moveSpeed;   //Handling user input.

        rb.velocity = new Vector2(dir, rb.velocity.y);
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
