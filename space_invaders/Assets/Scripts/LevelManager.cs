using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    public int score = 0;

    public IntUnityEvent onScoreUpdate = new IntUnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore(int addPoints)
    {
        score += addPoints;
        onScoreUpdate.Invoke(addPoints);
    }

    void OnSceneLoaded(Scene loadedScene, LoadSceneMode sceneMode)
    {
        Enemy enemyComponent = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        enemyComponent.onDeath.AddListener(() => UpdateScore(enemyComponent.points));

        Debug.Log(loadedScene.name);
        //UpdateScore(score);
    }

}
