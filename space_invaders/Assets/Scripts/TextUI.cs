using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.GetComponent<TextMeshProUGUI>();

        LevelManager.instance.onScoreUpdate.AddListener(GetScore);

        GetScore(LevelManager.instance.score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetScore(int newScore)
    {
        scoreText.text = string.Format("Score: {0}", newScore);
    }
}
