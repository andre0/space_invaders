using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D playerCollider;
    private Rigidbody2D playerRigidbody;
    private float speed = 7.5f;
    public GameObject blasterPrefab;
    private int lives = 3;

    private float fireRate;

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

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > fireRate)
            {
                Shoot();
                fireRate = Time.time + 1.3f; // 1.3 is the firerate
            }
        }
    }
        
    void Move()
    {
        float movementX = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = playerRigidbody.velocity;
        playerRigidbody.velocity = new Vector2(movementX * speed, currentVelocity.y);
    }

    void Shoot()
    {
        GameObject blaster = Instantiate(blasterPrefab, this.transform.position, Quaternion.identity);
        blaster.GetComponent<Rigidbody2D>().velocity = Vector2.up * 8;
        Physics2D.IgnoreCollision(playerCollider, blaster.GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EnemyBlaster"))
        {
            lives -= 1;
            if (lives == 0)
            {
                // gameover
            }
        }
    }
}
