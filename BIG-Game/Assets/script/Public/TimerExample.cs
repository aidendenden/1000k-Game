using UnityEngine;

public class TimerExample : MonoBehaviour
{
    public float timer = 0.0f;
    public float delayTime = 60.0f;

    void Update()
    {
        // 累积时间
        timer += Time.deltaTime;

        // 当累积时间超过延迟时间时调用函数并重置计时器
        if (timer >= delayTime)
        {
            MyFunction();
            timer = 0.0f; // 重置计时器
        }
    }

    void MyFunction()
    {
        // 这里放置你想要在一定时间后执行的代码
        Debug.Log("MyFunction被调用了！");
    }
}