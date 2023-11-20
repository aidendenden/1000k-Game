using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public int sceneNum;

    private bool changeing = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (changeing == false)
        {
            LoadNextLevel();
            changeing = true;
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