using UnityEngine;

public class TimerExample : MonoBehaviour
{
    public float timer = 0.0f;
    public float delayTime = 60.0f;

    void Update()
    {
        // �ۻ�ʱ��
        timer += Time.deltaTime;

        // ���ۻ�ʱ�䳬���ӳ�ʱ��ʱ���ú��������ü�ʱ��
        if (timer >= delayTime)
        {
            MyFunction();
            timer = 0.0f; // ���ü�ʱ��
        }
    }

    void MyFunction()
    {
        // �����������Ҫ��һ��ʱ���ִ�еĴ���
        Debug.Log("MyFunction�������ˣ�");
    }
}