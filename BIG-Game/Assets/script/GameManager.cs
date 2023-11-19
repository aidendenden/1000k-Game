using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
