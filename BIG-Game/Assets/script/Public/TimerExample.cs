using UnityEngine;
using UnityEngine.Events;

public class TimerExample : MonoBehaviour
{
    public float timer = 0.0f;
    public float delayTime = 60.0f;
    private PointManager pointManager;
    public UnityEvent TimeEnd;
    

    private void Start()
    {
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
    }
    void Update()
    {
        // �ۻ�ʱ��
        timer += Time.deltaTime;
        pointManager.addTime(Time.deltaTime);

        // ���ۻ�ʱ�䳬���ӳ�ʱ��ʱ���ú��������ü�ʱ��
        if (timer >= delayTime)
        {
            MyFunction();
            timer = 0.0f; // ���ü�ʱ��
           
        }
    }

    void MyFunction()
    {
        TimeEnd.Invoke();
    }

    public void ChangeTime(float a)
    {
        if (timer + a <=0)
        {
            timer = 0;
        }
        else
        {
            timer += a;
        }
    }
}