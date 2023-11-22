using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 3f;

    public int sceneNum;

    private bool changeing = false;
    public float timeDown = 1f;
    public int bottonHard = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (changeing == false)
        {
            if (bottonHard >=2)
            {
                LoadNextLevel();
                changeing = true;
                bottonHard = 0;
            }
            else
            {
                bottonHard++;
            }
           
        }
        
    }

    private void Update()
    {
        if (timeDown <0)
        {
            if (bottonHard -1>0)
            {
                bottonHard--;
            }
            else
            {
                bottonHard = 0;
            }
            timeDown = 1;
        }
        else
        {
            timeDown -= Time.deltaTime;
        }
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(LoadLevel(sceneNum));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        if (transition)
        {
            transition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}