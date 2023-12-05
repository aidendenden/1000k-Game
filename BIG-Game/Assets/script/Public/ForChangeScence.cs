using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForChangeScence : MonoBehaviour
{

    public bool isWait = false;
    public string sceneToSwitchTo; // �������ַ�������������ָ��Ҫ�л����ĳ���

    private Animator ani;


    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
    // �����ĺ����������л���ָ���ĳ���
    public void SwitchScene()
    {
        // ʹ��SceneManager��LoadScene�������л�����
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
