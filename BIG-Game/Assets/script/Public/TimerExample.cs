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
        // 累积时间
        timer += Time.deltaTime;
        pointManager.addTime(Time.deltaTime);

        // 当累积时间超过延迟时间时调用函数并重置计时器
        if (timer >= delayTime)
        {
            MyFunction();
            timer = 0.0f; // 重置计时器
           
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