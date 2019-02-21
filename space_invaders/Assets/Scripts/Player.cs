﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player instance;

    public UnityEvent onLoseLife;

    private Collider2D playerCollider;
    private Rigidbody2D playerRigidbody;
    private float speed = 7.5f;
    public GameObject blasterPrefab;

    private float fireRate;

    void Awake()
    {
        instance = this;
    }

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBlaster"))
        {
            this.gameObject.SetActive(false);

            onLoseLife.Invoke();
            
            
            Invoke("respawn", 3); // Respawn after 3 seconds

            // Instantiate a new player?
        }
        else if (collision.CompareTag("Enemy"))
        {
            // game over
        }
    }

    void respawn()
    {
        this.playerRigidbody.position = new Vector2(-2.25f, this.playerRigidbody.position.y);
        this.gameObject.SetActive(true);
    }

}
