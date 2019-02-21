using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesText : MonoBehaviour
{
    TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText = this.GetComponent<TextMeshProUGUI>();
        LevelManager.instance.onLivesUpdate.AddListener(UpdateLives);

        UpdateLives(LevelManager.instance.lives);
        
    }

    void UpdateLives(int newLives)
    {
        livesText.text = string.Format("Lives: {0}", newLives);
    }
}
