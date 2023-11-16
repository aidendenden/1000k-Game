using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider; // 引用Slider对象
    public MusicPoint musicPoint;
  

    // 设置进度条的值
    public void SetProgress(float value)
    {
        slider.value = value;
    }

    // 设置进度条的最大值
    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = 0; // 确保进度条的初始值等于最大值
    }
    private void Start()
    {
        SetMaxValue(80);
    }
    private void Update()
    {
        SetProgress(musicPoint.point);
    }
}