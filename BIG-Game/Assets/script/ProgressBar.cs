using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider; // 引用Slider对象
    public MusicPoint musicPoint;
    public TimerExample timerExample;
    public int kind = 0;  

    // 设置进度条的值
    public void SetProgress(float value)
    {
        slider.value = value;
    }

    // 设置进度条的最大值
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = 0; // 确保进度条的初始值等于最大值
    }
    private void Start()
    {
        if(kind == 0)
        {
            SetMaxValue(80);
        }
        if (kind == 1)
        {
            SetMaxValue(timerExample.delayTime);
        }

    }
    private void Update()
    {
        if (kind ==0) { SetProgress(musicPoint.point); }
        if (kind == 1) { SetProgress(timerExample.timer); }

    }
}