using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForChangeScence : MonoBehaviour
{

    public bool isWait = false;
    public string sceneToSwitchTo; // 公开的字符串变量，用于指定要切换到的场景

    private Animator ani;


    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
    // 公开的函数，用于切换到指定的场景
    public void SwitchScene()
    {
        // 使用SceneManager的LoadScene函数来切换场景
        SceneManager.LoadScene(sceneToSwitchTo);
    }

    public void CanAnyKeySwitchScene()
    {
        isWait = true;
    }

    private void Update()
    {
        if (isWait)
        {
            if (Input.anyKeyDown)
            {
                ani.SetTrigger("Out");
                isWait = false;
            }
        }
    }
}
