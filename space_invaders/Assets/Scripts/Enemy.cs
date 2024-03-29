﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntUnityEvent : UnityEvent<int> { }
public class Enemy : MonoBehaviour
{

    public UnityEvent onDeath;
    public GameObject enemyBlasterPrefab;

    private Rigidbody2D enemyRigidbody;
    private Collider2D enemyCollider;

    public int points = 10;

    private float randomFire = 0.0f;

    void Start()
    {
        enemyRigidbody = this.GetComponent<Rigidbody2D>();
        enemyCollider = this.GetComponent<Collider2D>();

        randomFire = Time.time + Random.Range(0.0f, 100.0f);

    }

    private void Update()
    {
        if (Time.time > this.randomFire)
        {
            randomFire = Time.time + Random.Range(10.0f, 100.0f);
            Enemy_Shoot();
        }
    }

    void Enemy_Shoot()
    {
        GameObject enemy_blaster = Instantiate(enemyBlasterPrefab, this.transform.position, Quaternion.identity);
        enemy_blaster.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
        Physics2D.IgnoreCollision(enemyCollider, enemy_blaster.GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("blaster"))
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);

            onDeath.Invoke();
        }
    }

}
