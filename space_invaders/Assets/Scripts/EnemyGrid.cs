using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    //public GameObject[] enemies;
    private Transform Enemies;
    private Rigidbody2D gridRigidbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        gridRigidbody = this.GetComponent<Rigidbody2D>();
        Enemies = this.GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //Vector2 enemyVelocity = gridRigidbody.velocity;
        //gridRigidbody.velocity = new Vector2(1 * speed, gridRigidbody.velocity.y);
        Enemies.position += Vector3.right * speed;
        foreach (Transform enemy in Enemies)
        {
            if (enemy.position.x > 11.0 || enemy.position.x < -11.0)
            {
                speed = (-1) * speed;
                Enemies.position += Vector3.down * 0.2f;
                return;
            }
        }
    }
    
}
