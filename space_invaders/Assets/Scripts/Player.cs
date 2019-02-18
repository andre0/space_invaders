using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D playerCollider;
    private Rigidbody2D playerRigidbody;
    private float speed = 7.5f;
    public GameObject blasterPrefab;

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
            Debug.Log("Shoot");
            Shoot();
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
        
    }
}
