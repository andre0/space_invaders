using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player instance;

    public UnityEvent onLoseLife;
    public UnityEvent onLoseGame;

    private Collider2D playerCollider;
    private Rigidbody2D playerRigidbody;
    private float speed = 7.5f;
    public GameObject blasterPrefab;

    private float fireRate;

    private GameObject[] getCount;
    public int count = 0;

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
        getCount = GameObject.FindGameObjectsWithTag("blaster");
        count = getCount.Length;

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > fireRate)
            {
                if (count == 0)
                {
                    Shoot();
                }
                
                fireRate = Time.time + 0.1f; // 1.3 is the firerate
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
            onLoseGame.Invoke();
        }
    }

    void respawn()
    {
        this.gameObject.SetActive(true);
    }

}
