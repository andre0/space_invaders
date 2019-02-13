using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D playerCollider;
    private Rigidbody2D playerRigidbody;
    private float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
        
    void Move()
    {
        float movementX = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = playerRigidbody.velocity;
        playerRigidbody.velocity = new Vector2(movementX * speed, currentVelocity.y);
    }

    void Shoot()
    {

    }
}
