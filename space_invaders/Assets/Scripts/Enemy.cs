using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent onDeath;
    private Rigidbody2D enemyRigidbody;
    private Collider2D enemyCollider;
    public int points = 10;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("blaster"))
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);

            // score += points;
            onDeath.Invoke();
        }
    }

}
