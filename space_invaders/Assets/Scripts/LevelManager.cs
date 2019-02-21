using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
 
    public static LevelManager instance;

    public int score = 0;
    public int lives = 3;

    public IntUnityEvent onScoreUpdate = new IntUnityEvent();
    public IntUnityEvent onLivesUpdate = new IntUnityEvent();

    public Enemy[] enemies;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemies = FindObjectsOfType<Enemy>();
        
        foreach(Enemy enemy in enemies)
        {
            enemy.onDeath.AddListener(() => UpdateScore(enemy.points));
        }

        Player.instance.onLoseLife.AddListener(() => UpdateLives(--lives));
    }

    void UpdateScore(int addPoints)
    {
        score += addPoints;
        onScoreUpdate.Invoke(score);
    }

    void UpdateLives(int newLives)
    {
        lives = newLives;
        onLivesUpdate.Invoke(newLives);
    }
}
