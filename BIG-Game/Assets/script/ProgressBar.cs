using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider; // ����Slider����
    public MusicPoint musicPoint;
    public TimerExample timerExample;
    public int kind = 0;  

    // ���ý�������ֵ
    public void SetProgress(float value)
    {
        slider.value = value;
    }

    // ���ý����������ֵ
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = 0; // ȷ���������ĳ�ʼֵ�������ֵ
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