using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public bool isPaused;

    public static GameManager Instance
    {
        get { return _instance; }
    }
    
    void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        isPaused = false;
    }
    
    public void Pause()
    { 
        isPaused = true;
        Time.timeScale = 0;
    }
    
    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
