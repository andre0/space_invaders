using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public GameObject[] enemies;

    // Start is called before the first frame update
    //public float speed;
    //private Transform Enemies;
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
        }
    }

}
