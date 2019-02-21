using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public GameObject playAgain;
    public GameObject quit;
    public GameObject gameOver;
    public GameObject winner;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkGame();
    }

    public void checkGame()
    {
        if (LevelManager.instance.lives < 1 || LevelManager.instance.score == 1100)
        {

            Time.timeScale = 0;
            GameObject enemyGrid = GameObject.Find("EnemyGrid");
            enemyGrid.GetComponent<EnemyGrid>().enabled = false;
            playAgain.SetActive(true);
            quit.SetActive(true);
            
            if (LevelManager.instance.lives < 1)
            {
                gameOver.SetActive(true);
            }

            if (LevelManager.instance.score == 1100)
            {
                winner.SetActive(true);
            }
            

        }

    }
}
