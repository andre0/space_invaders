﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("level");

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

