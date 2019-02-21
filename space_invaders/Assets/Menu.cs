﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartLevel()
    {
        SceneManager.LoadScene("level");

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

